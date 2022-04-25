using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public bool hasItem = false;
    public Sprite itemIcon;
    public Item item;

    SpriteRenderer itemSprite;
    // Start is called before the first frame update
    void Start()
    {
        itemSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateIcon(Sprite icon){
        itemIcon = icon;
        itemSprite.sprite = itemIcon;
    }
}
