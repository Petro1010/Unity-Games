using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

// Fortune Farmer Namespace
namespace FortuneFarmer
{
    // Game Controller Class
    public class GameController : MonoBehaviour
    {

        //Creating a singleton reference of gamecontroller
        public static GameController instance;

        void Awake() {
            if (instance != null)
            {
                Debug.LogWarning("Error! Attempting to make more than one instance of game controller");
                return;
            }
            instance = this;
            this.Start();
        }
        // start method run before first frame update
        public void Start()
        {
            loadPlayerSaveData();
            
        }

        public void loadPlayerSaveData()
        {
            InventoryInfo.Load();   
            EnvironmentInfo.Load();
            GameStatusInfo.Load();
        }

        public void updatePlayerSaveData(int _coins, List<Item> _inventory, int _time, string _weather, string _lastScene)
        {
            InventoryInfo.Update(_coins, _inventory);
            EnvironmentInfo.Update(_time, _weather);
            GameStatusInfo.Update(_lastScene);
        }

        public void updatePlayerSaveData(int _coins, List<Item> _inventory)
        {
            InventoryInfo.Update(_coins, _inventory);
        }

        public void updatePlayerSaveData(int _time, string _weather)
        {
            EnvironmentInfo.Update(_time, _weather);
        }

        public void updatePlayerSaveData(string _lastScene)
        {
            GameStatusInfo.Update(_lastScene);
        }

        public void savePlayerData()
        {
            InventoryInfo.Save();
            EnvironmentInfo.Save();
            GameStatusInfo.lastScene = SceneManager.GetActiveScene().name;
            GameStatusInfo.Save();
            Debug.Log("Last Scene: " + GameStatusInfo.lastScene);
        }

        public (int, List<Item>) getInventoryData()
        {
            return (InventoryInfo.coins, InventoryInfo.inventory);
        }

        public (int, string) getEnvironmentData()
        {
            return (EnvironmentInfo.time, EnvironmentInfo.weather);
        }

        public string getGameStatusData()
        {
            return GameStatusInfo.lastScene;
        }

        public void openMap()
        {
            savePlayerData();
            SceneManager.LoadScene("MapUI");
        }

        public void goToSettings()
        {
            savePlayerData();
            SceneManager.LoadScene("SettingsUI");
        }

        public void goToInventory()
        {
            savePlayerData();
            SceneManager.LoadScene("InventoryUI");
        }

        public void goBack()
        {
            Debug.Log("returning to " + GameStatusInfo.lastScene);
            SceneManager.LoadScene(GameStatusInfo.lastScene);
        }

        public void ExitGame()
        {
            Debug.Log("Exited Game!");
            Application.Quit();
        }
    }
}

