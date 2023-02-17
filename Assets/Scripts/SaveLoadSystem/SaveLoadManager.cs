﻿using System.IO;
using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace SaveLoadSystem
{
    public static class SaveLoadManager
    {
        public static SaveData CurrentSaveData = new SaveData();

        private const string SaveDirectory = "/SaveData/";
        private const string FileName = "TheMorgueSaveData.sav";

        public static void SaveGame()
        {
            var dir = Application.persistentDataPath + SaveDirectory;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string json = JsonUtility.ToJson(CurrentSaveData, true);
            File.WriteAllText(dir + FileName, json);

            GUIUtility.systemCopyBuffer = dir;
        }

        public static void LoadGame()
        {
            string fullPath = Application.persistentDataPath + SaveDirectory + FileName;
            SaveData tempData = new SaveData();

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                tempData = JsonUtility.FromJson<SaveData>(json);
            }

            CurrentSaveData = tempData;
        }
    }
}