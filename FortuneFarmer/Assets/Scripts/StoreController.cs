using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using FortuneFarmer;

namespace FortuneFarmer
{
    public class StoreController : MonoBehaviour
    {
        //Creating a singleton reference of StoreController
        public static StoreController instance;

        void Awake() {
            if (instance != null)
            {
                Debug.LogWarning("Error! Attempting to make more than one instance of Store Controller");
                return;
            }
            instance = this;
        }
        // boundary class variables
        private int coins;
        private List<Item> inventory;
        private string lastScene;

        [SerializeField] private TextMeshProUGUI CoinBalance;

        // Start is called before the first frame update
        public void Start()
        {
            //GameController.instance.Start();
            this.displayStoreInfo();
            Debug.Log(SceneManager.GetActiveScene().name + " scene loaded");
        }


    // I dont think the store info should be loading inventory data? It should probably have its own StoreInfo to load from.
        public void displayStoreInfo()
        {
            (coins, inventory) = GameController.instance.getInventoryData();
            lastScene = GameController.instance.getGameStatusData();
            CoinBalance.text = $"Coins: {coins}";
        }

        public void updateStoreInfo()
        {
            GameController.instance.updatePlayerSaveData(coins, inventory);
            GameController.instance.updatePlayerSaveData(lastScene);
        }

        public void purchaseItem(Item item)
        {
            if (item.buyPrice <= coins && inventory.Count < 40){
                coins -= item.buyPrice;
                this.updateStoreInfo();
                this.displayStoreInfo();
                Debug.Log("Step 1");
                //this.updateInventory(item);
                //inventory.Add(item);
                Debug.Log("Step 2");
                //this.updateStoreInfo();
                Debug.Log("Step 3");
                //this.displayStoreInfo();
                Debug.Log("Step 4");
                //InventoryUI.instance.UpdateInventorySlot(item);
                Debug.Log("item purchased");
            }
            
        }

        public void sellItem(Item item)
        {
            Debug.Log("item sold");
        }

        public void updateCoinBalance()
        {
            Debug.Log("coin balance updated");
        }

        public void updateShopItems()
        {
            Debug.Log("shop items updated");
        }

        public void getInventory()
        {
            Debug.Log("inventory loaded");
        }

        public void getItemList()
        {
            Debug.Log("item list loaded");
        }

        public void generateTips()
        {
            Debug.Log("tips generated");
        }

        public void goToMap()
        {
            lastScene = SceneManager.GetActiveScene().name;
            this.updateStoreInfo();
            SceneManager.LoadScene("MapUI");
        }

        public void goToSettings()
        {
            lastScene = SceneManager.GetActiveScene().name;
            this.updateStoreInfo();
            SceneManager.LoadScene("SettingsUI");
        }

        public void goToInventory()
        {
            lastScene = SceneManager.GetActiveScene().name;
            this.updateStoreInfo();
            SceneManager.LoadScene("InventoryUI");
        }
    }
}

