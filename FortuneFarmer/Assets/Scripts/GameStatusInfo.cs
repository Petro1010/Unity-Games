using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


// Fortune Farmer Namespace
namespace FortuneFarmer
{
    // Game Status Info Entity Class
    public static class GameStatusInfo
    {
        public static string lastScene;

        // Load Game Status Info data from save file
        public static void Load()
        {
            // checks if save file already exists
            if (File.Exists(Application.persistentDataPath + "/GameStatusInfo.dat"))
            {
                // opening save file
                BinaryFormatter binFormat = new BinaryFormatter();
                FileStream saveFile = File.Open(Application.persistentDataPath + "/GameStatusInfo.dat", FileMode.Open);
                // extracting and loading serializable class (and saved data) from save file
                GameStatusInfoData gameStatusInfoData = (GameStatusInfoData) binFormat.Deserialize(saveFile);
                saveFile.Close();
                lastScene = gameStatusInfoData.GetGameStatusInfoData();
            }
            else
            {
                lastScene = SceneManager.GetActiveScene().name;
                Debug.Log(lastScene);
            }
        }

        // Update Game Status Info data from Game Controller
        public static void Update(string _lastScene)
        {
            lastScene = _lastScene;
        }

        // Save Game Status Info data into save file
        public static void Save()
        {
            // preparing and opening save file
            BinaryFormatter binFormat = new BinaryFormatter();
            FileStream saveFile = File.Open(Application.persistentDataPath + "/GameStatusInfo.dat", FileMode.OpenOrCreate);
            // loading game status info into serializable class
            GameStatusInfoData gameStatusInfoData = new GameStatusInfoData(lastScene);
            // saving serializable class (and loaded data) into save file
            binFormat.Serialize(saveFile, gameStatusInfoData);
            saveFile.Close();
        }
    }

    // Game Status Info Data Class
    [Serializable] class GameStatusInfoData
    {
        public string lastScene;

        // construct class with game status info
        public GameStatusInfoData(string _lastScene)
        {
            lastScene = _lastScene;
        }

        // get game status info
        public string GetGameStatusInfoData()
        {
            return lastScene;
        }
    }
}

