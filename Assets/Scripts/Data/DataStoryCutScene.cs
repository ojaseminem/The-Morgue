using Managers;
using UnityEngine;
using UnityEngine.Timeline;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/StoryCutScene")]
    public class DataStoryCutScene : ScriptableObject
    {
        public CurrentStoryCutSceneData[] storyCutSceneData;
        
        [System.Serializable]
        public class CurrentStoryCutSceneData
        {
            public StoryProgressStates currentStoryProgressStates;
            public TimelineAsset currentCutSceneAsset;
        }
    }
}