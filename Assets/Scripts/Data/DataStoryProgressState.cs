using Managers;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/StoryState")]
    public class DataStoryProgressState : ScriptableObject
    {
        public CurrentStoryProgressData[] storyProgressState;
        
        [System.Serializable]
        public class CurrentStoryProgressData
        {
            public StoryProgressStates currentStoryProgressStates;
            public bool cutScene;
            public bool saveAtThisState;
        }
    }
}