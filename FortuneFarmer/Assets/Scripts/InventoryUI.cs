using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace FortuneFarmer
{
    public class InventoryUI : MonoBehaviour
    {
        //Creating a singleton reference of InventoryUI
        public static InventoryUI instance;

        void Awake() {
            if (instance != null)
            {
                Debug.LogWarning("Error! Attempting to make more than one instance of InventoryUI");
                return;
            }
            instance = this;
        }
        // boundary class variables
        private int coins;
        private List<Item> inventory;
        private string lastScene;
        private List<InventorySlot> inventorySlots;

        [SerializeField] private TextMeshProUGUI CoinBalance;

        // Start is called before the first frame update
        void Start()
        {
            //GameController.instance.Start();
            inventorySlots = new List<InventorySlot>();
            for (int i = 0; i < 40; i++){
                Debug.Log("SUiiii");
                inventorySlots.Add(this.gameObject.transform.GetChild(2).GetChild(0).GetChild(i).GetComponent<InventorySlot>());  //get all the inventory slots
            }

            Debug.Log(inventorySlots.Count);

        }

        public void DisplayInventoryInfo()
        {
            (coins, inventory) = GameController.instance.getInventoryData();
            lastScene = GameController.instance.getGameStatusData();
            CoinBalance.text = $"Coins: {coins}";
        }

        public void UpdateInventorySlot(Item item)
        {
            Debug.Log("Yel");
            for (int i = 0; i < 40; i++){  //search for an empty slot
                if (!inventorySlots[i].hasItem){
                    //Slot is now occupied, update its icon and what item it currently holds
                    inventorySlots[i].hasItem = true;
                    inventorySlots[i].item = item;
                    inventorySlots[i].updateIcon(item.icon);
                }
            }
        }

        public void UpdateInventoryInfoSave()
        {
            GameController.instance.updatePlayerSaveData(coins, inventory);
            GameController.instance.updatePlayerSaveData(lastScene);
        }

        public void GoBack()
        {
            GameController.instance.goBack();
        }

        public void GoToSettings()
        {
            lastScene = SceneManager.GetActiveScene().name;
            this.UpdateInventoryInfoSave();
            SceneManager.LoadScene("SettingsUI");
        }
    }
}
