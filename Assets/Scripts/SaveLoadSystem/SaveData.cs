using Data;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    
    public class SaveData
    {
        //Game Story Variables
        public StoryProgressStates lastStoryProgressStates = StoryProgressStates.Idle;
        

        //Player Variables
        public Vector3 playerPosition;
        public bool hasLockPick;
        public bool hasFlash;
        public bool hasMap;
        
        //Equipment Variables
        public int flashBattery;
        public int lockPickCount;
        //map render target
        
        //Environment Variables
        //public Vector3[] envData;
        //public bool[] envDataActive;

        //Enemy - Scientist Variables

    }
}