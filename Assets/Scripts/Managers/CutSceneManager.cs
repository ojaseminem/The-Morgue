using System.Collections;
using System.Linq;
using Data;
using Misc;
using UI;
using UnityEngine;
using UnityEngine.Playables;

namespace Managers
{
    public class CutSceneManager : MonoBehaviour
    {
        public static CutSceneManager Instance;
        private void Awake() => Instance = this;

        [SerializeField] private DataStoryCutScene storyCutSceneData;
        [SerializeField] private PlayableDirector playableDirector;

        private bool _currentlyPlaying;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _currentlyPlaying)
            {
                SkipCutScene();
            }
        }

        public void PlayCutScene(StoryProgressStates sp)
        {
            StartCoroutine(PlayingCutScene(sp));
        }

        private IEnumerator PlayingCutScene(StoryProgressStates currSp)
        {
            DataStoryCutScene.CurrentStoryCutSceneData CurrentStoryCutSceneDataIndex()
            {
                return storyCutSceneData.storyCutSceneData
                    .FirstOrDefault(currentStoryCutSceneData => 
                        currentStoryCutSceneData.currentStoryProgressStates == currSp);
            }
            
            CutSceneCameraHandler.SetPriority(2);
            
            FirstPersonController.ToggleAudioListener(false);
            CutSceneCameraHandler.ToggleAudioListener(true);

            playableDirector.enabled = true;
            GameManager.Instance.canChangeState = false;
            
            yield return new WaitForSeconds(0.05f);
            
            playableDirector.Play(CurrentStoryCutSceneDataIndex().currentCutSceneAsset);

            _currentlyPlaying = true;

            var dur = playableDirector.duration;
            yield return new WaitForSeconds((float)dur);
            
            playableDirector.Stop();
            
            _currentlyPlaying = false;

            yield return new WaitForSeconds(0.05f);
            
            playableDirector.enabled = false;
            GameManager.Instance.canChangeState = true;

            CutSceneCameraHandler.SetPriority(0);

            CutSceneCameraHandler.ToggleAudioListener(false);
            FirstPersonController.ToggleAudioListener(true);

            GameManager.Instance.ChangeGameState(GameState.CheckState);
        }
        
        public void SkipCutScene()
        {
            StopAllCoroutines();
            StartCoroutine(SkippingCutScene());
        }

        private IEnumerator SkippingCutScene()
        {
            var fadeObject = UIManager.Instance.SpawnObject(SpawnableUIObjects.ScreenFade);
            
            yield return new WaitUntil(() => fadeObject.GetComponent<ScreenFadeHandler>().eventTriggered);
            
            _currentlyPlaying = false;

            playableDirector.Stop();
            
            CutSceneCameraHandler.SetPriority(0);

            CutSceneCameraHandler.ToggleAudioListener(false);
            FirstPersonController.ToggleAudioListener(true);
            
            yield return new WaitForSeconds(0.05f);
            
            GameManager.Instance.canChangeState = true;
            GameManager.Instance.ChangeGameState(GameState.CheckState);
        }
    }
}