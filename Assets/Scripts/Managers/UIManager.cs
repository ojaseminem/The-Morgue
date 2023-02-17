using System;
using Data;
using UnityEngine;

namespace Managers
{
    [Serializable]
    public struct SpawnableObjects
    {
        public SpawnableUIObjects spawnableObject;
        public GameObject spawnableObjectPrefab;
    }
    
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        private void Awake() => Instance = this;

        public Transform panel;
        
        public SpawnableObjects[] spawnableObjectsArray;

        private void Start()
        {
            //Validate References
            
        }

        public void SaveGame()
        {
            GameManager.Instance.SaveData();
        }

        public void LoadGame()
        {
            GameManager.Instance.LoadData();
        }

        public GameObject SpawnObject(SpawnableUIObjects objects)
        {
            switch (objects)
            {
                case SpawnableUIObjects.ScreenFade:
                    var go = 
                        Instantiate(
                            spawnableObjectsArray[GetSpawnableObject(objects)]
                                .spawnableObjectPrefab, panel.parent, false);
                    return go;
                default:
                    throw new ArgumentOutOfRangeException(nameof(objects), objects, "Threw Exception");
            }
        }

        private int GetSpawnableObject(SpawnableUIObjects uiObjects)
        {
            for (int i = 0; i < spawnableObjectsArray.Length; i++)
            {
                if (spawnableObjectsArray[i].spawnableObject == uiObjects) return i;
            }
            return -1;
        }
        
        public void EnableHud()
        {
            
        }
        
        public void DisableHud()
        {
            //DisableUI and enable cutscene UI
        }
    }
}