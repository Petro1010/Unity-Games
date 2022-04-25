using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// Fortune Farmer Namespace
namespace FortuneFarmer
{
    // Inventory Info Entity Class
    public static class InventoryInfo
    {
        // Inventory Info Entity Class Variables
        public static int coins;
        public static List<Item> inventory;

        // Load Inventory Info data from save file
        public static void Load()
        {
            // checks if save file already exists
            if (File.Exists(Application.persistentDataPath + "/InventoryInfo.dat"))
            {
                // opening save file
                BinaryFormatter binFormat = new BinaryFormatter(); 
                FileStream saveFile = File.Open(Application.persistentDataPath + "/InventoryInfo.dat", FileMode.Open);
                // extracting and loading serializable class (and saved data) from save file
                InventoryInfoData inventoryInfoData = (InventoryInfoData) binFormat.Deserialize(saveFile);
                (coins, inventory) = inventoryInfoData.GetInventoryInfoData();
                saveFile.Close();
            }
            else
            {
                coins = 0;
                inventory = new List<Item>();
            }
        }

        

        // Update Inventory Info data from Game Controller
        public static void Update(int _coins, List<Item> _inventory)
        {
            coins = _coins;
            inventory = _inventory;
        }

        // Save Inventory Info data into save file
        public static void Save()
        {
            // preparing and opening save file
            BinaryFormatter binFormat = new BinaryFormatter();
            FileStream saveFile = File.Open(Application.persistentDataPath + "/InventoryInfo.dat", FileMode.OpenOrCreate);
            // loading inventory info into serializable class
            InventoryInfoData inventoryInfoData = new InventoryInfoData(coins, inventory);
            // saving serializable class (and loaded data) into save file
            binFormat.Serialize(saveFile, inventoryInfoData);
            saveFile.Close();
        }

        //Add an item to the inventory. Returns the result of the operation
        public static bool add(Item item) {
            if (inventory.Count >= 40) {
                Debug.Log("Inventory is full!");
                return false;
            }
            inventory.Add(item);
            return true;
        }
        //Remove an item from the inventory. Returns the result of the operation
        public static bool remove(Item item) {
            if (!inventory.Contains(item)) {
                Debug.Log(item.name + " is not in inventory");
                return false;
            }
            inventory.Add(item);
            return true;
        }

        //Change coin balance by amount given. Returns the result of the operation
        public static bool updateCoins(int amount) {
            //only update
            if (coins + amount >= 0) {
                coins += amount;
                return true;
            }
            return false;
        }
    }

    // Inventory Info Data Class
    [Serializable] class InventoryInfoData
    {
        public int coins;
        public List<Item> inventory;

        // construct class with inventory info
        public InventoryInfoData(int _coins, List<Item> _inventory)
        {
            coins = _coins;
            inventory = _inventory;
        }

        // get inventory info
        public (int, List<Item>) GetInventoryInfoData()
        {
            return (coins, inventory);
        }
    }
}

