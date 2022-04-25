using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreItem : MonoBehaviour
{
    public Item item;
    public TMP_Text priceText;

    void Start()
    {
        priceText.text = "$" + item.buyPrice.ToString();
    }
}
