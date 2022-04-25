using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// Fortune Farmer Namespace
namespace FortuneFarmer
{
    // Environment Info Entity Class
    public static class EnvironmentInfo
    {
        public static int time;
        public static string weather;

        // Load Environment Info data from save file
        public static void Load()
        {
            // checks if save file already exists
            if (File.Exists(Application.persistentDataPath + "/EnvironmentInfo.dat"))
            {
                // opening save file
                BinaryFormatter binFormat = new BinaryFormatter();
                FileStream saveFile = File.Open(Application.persistentDataPath + "/EnvironmentInfo.dat", FileMode.Open);
                // extracting and loading serializable class (and saved data) from save file
                EnvironmentInfoData environmentInfoData = (EnvironmentInfoData) binFormat.Deserialize(saveFile);
                saveFile.Close();
                (time, weather) = environmentInfoData.GetEnvironmentInfoData();

                if (weather == "")
                {
                    weather = "Sunny";
                }
            }
            else
            {
                time = 0;
                weather = "Sunny";
            }
        }

        // Update Environment Info data from Game Controller
        public static void Update(int _time, string _weather)
        {
            time = _time;
            weather = _weather;
        }

        // Save Environment Info data into save file
        public static void Save()
        {
            // preparing and opening save file
            BinaryFormatter binFormat = new BinaryFormatter();
            FileStream saveFile = File.Open(Application.persistentDataPath + "/EnvironmentInfo.dat", FileMode.OpenOrCreate);
            // loading environment info into serializable class
            EnvironmentInfoData environmentInfoData = new EnvironmentInfoData(time, weather);
            // saving serializable class (and loaded data) into save file
            binFormat.Serialize(saveFile, environmentInfoData);
            saveFile.Close();
        }
    }


    // Environment Info Data Class
    [Serializable] class EnvironmentInfoData
    {
        public int time;
        public string weather;

        // construct class with environment info
        public EnvironmentInfoData(int _time, string _weather)
        {
            time = _time;
            weather = _weather;
        }

        // get environment info
        public (int, string) GetEnvironmentInfoData()
        {
            return (time, weather);
        }
    }
}

