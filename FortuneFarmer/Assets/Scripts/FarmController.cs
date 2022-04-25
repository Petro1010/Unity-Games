using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace FortuneFarmer
{
    public class FarmController : MonoBehaviour
    {
        //Creating a singleton reference of FarmController
        public static FarmController instance;

        void Awake() {
            if (instance != null)
            {
                Debug.LogWarning("Error! Attempting to make more than one instance of Farm Controller");
                return;
            }
            instance = this;
        }
        // boundary class variables
        private int coins;
        private List<Item> inventory;
        private int time;
        private string weather;
        private string lastScene;

        [SerializeField] private TextMeshProUGUI FarmInfo;

        // constructor method
        public void Start()
        {
            //GameController.instance.Start();
            this.displayFarmInfo();
            Debug.Log(SceneManager.GetActiveScene().name + " scene loaded");
        }

        public void displayFarmInfo()
        {
            (coins, inventory) = GameController.instance.getInventoryData();
            (time, weather) = GameController.instance.getEnvironmentData();
            lastScene = GameController.instance.getGameStatusData();

            FarmInfo.text = $"Coins: {coins}\nTime: {time}\nWeather: {weather}";
        }

        public void updateFarmInfo()
        {
            GameController.instance.updatePlayerSaveData(coins, inventory, time, weather, lastScene);
        }

        public void openMap()
        {
            lastScene = SceneManager.GetActiveScene().name;
            this.updateFarmInfo();
            GameController.instance.openMap();
        }

        public void goToSettings()
        {
            lastScene = SceneManager.GetActiveScene().name;
            this.updateFarmInfo();
            GameController.instance.goToSettings();
        }

        public void goToInventory()
        {
            lastScene = SceneManager.GetActiveScene().name;
            this.updateFarmInfo();
            GameController.instance.goToInventory();
        }

        public void selectTile(string _tile)
        {
            Debug.Log($"{_tile} tile selected");
        }

        public void exitGame()
        {
            GameController.instance.ExitGame();
        }
    }
}

