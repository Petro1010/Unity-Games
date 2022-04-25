using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FortuneFarmer
{
    // Map Controller Class
    public class MapController : MonoBehaviour
    {
        //Creating a singleton reference of MapController
        public static MapController instance;

        void Awake() {
            if (instance != null)
            {
                Debug.LogWarning("Error! Attempting to make more than one instance of Map Controller");
                return;
            }
            instance = this;
        }
        // boundary class variables
        private string lastScene;

        // constructor method
        void Start()
        {
           // GameController.instance.Start();
            this.displayMapInfo();
            Debug.Log(SceneManager.GetActiveScene().name + " scene loaded");
        }

        public void displayMapInfo()
        {
            lastScene = GameController.instance.getGameStatusData();
        }

        public void updateMapInfo()
        {
            GameController.instance.updatePlayerSaveData(lastScene);
        }

        public void goToFarm()
        {
            lastScene = SceneManager.GetActiveScene().name;
            this.updateMapInfo();
            SceneManager.LoadScene("MainUI");
        }

        public void goToMinigames()
        {
            lastScene = SceneManager.GetActiveScene().name;
            this.updateMapInfo();
            SceneManager.LoadScene("MinigameUI");
        }

        public void goToStore()
        {
            lastScene = SceneManager.GetActiveScene().name;
            this.updateMapInfo();
            SceneManager.LoadScene("StoreUI");
        }

        public void goToSettings()
        {
            lastScene = SceneManager.GetActiveScene().name;
            this.updateMapInfo();
            SceneManager.LoadScene("SettingsUI");
        }

    }
}

