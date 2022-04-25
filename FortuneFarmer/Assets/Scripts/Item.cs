using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName= "Inventory/Item")]  //This will give us the option to create the asset directly from the menu

public class Item : ScriptableObject
{
    public string itemName;
    public int buyPrice;
    public int sellPrice;
    public Sprite icon;


    public (string, int, int) GetItemInfo()
    {
        return (name, buyPrice, sellPrice);
    }

    public void DisplayItemInfo()
    {
        //print($"Name: {name}, Buy Price: {buyPrice}, Sell Price: {sellPrice}");
    }

}
