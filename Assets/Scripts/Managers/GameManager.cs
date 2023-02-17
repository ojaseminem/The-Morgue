using SaveLoadSystem;
using UnityEngine;

namespace Managers
{
    using Data;
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private void Awake() => Instance = this;

        //Script References
        [SerializeField] private DataStoryProgressState storyProgressStateData;

        public StoryProgressStates currentStoryProgressState;
        
        [HideInInspector] public bool canChangeState;
        
        private void Start()
        {
            //LoadData();
            canChangeState = true;
            ChangeGameState(GameState.CheckState);
        }

        public void ChangeGameState(GameState gameState)
        {
            if (!canChangeState) return;
            
            switch (gameState)
            {
                case GameState.CheckState:
                    CheckState();
                    break;
                case GameState.CutScene:
                    CutScene();
                    break;
                case GameState.GamePlay:
                    GamePlay();
                    break;
                case GameState.GameEnd:
                    GameEnd();
                    break;
            }
        }

        private void CheckState()
        {
            if (storyProgressStateData.storyProgressState[CurrentIndexCount(currentStoryProgressState)].saveAtThisState) SaveData();
            
            currentStoryProgressState++;
            int CurrentIndexCount(StoryProgressStates sp) => (int)sp;
            ChangeGameState(storyProgressStateData.storyProgressState[CurrentIndexCount(currentStoryProgressState)].cutScene
                ? GameState.CutScene
                : GameState.GamePlay);
        }

        private void CutScene()
        {
            print("cs");
            FirstPersonController.Instance.playerCanMove = false;
            CutSceneManager.Instance.PlayCutScene(currentStoryProgressState);
            UIManager.Instance.DisableHud();
        }

        private void GamePlay()
        {
            print("gp");
            //Enable Gameplay variables
            FirstPersonController.Instance.playerCanMove = true;
            UIManager.Instance.EnableHud();
        }

        private void GameEnd()
        {
            
        }

        public void SaveData()
        {
            SaveLoadManager.CurrentSaveData.lastStoryProgressStates = currentStoryProgressState;
            //Update variables
            SaveLoadManager.SaveGame();
        }

        public void LoadData()
        {
            SaveLoadManager.LoadGame();
            currentStoryProgressState = SaveLoadManager.CurrentSaveData.lastStoryProgressStates;
            //Update variables
        }
        
        public static void ToggleCursor(bool cursorOn) => Cursor.lockState = cursorOn ? CursorLockMode.None : CursorLockMode.Locked;
        
    }
}