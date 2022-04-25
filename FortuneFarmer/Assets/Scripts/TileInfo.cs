using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    //FarmController fc;
    private bool hasPlant = false;
    // Start is called before the first frame update
    void Start()
    {
        //fc = FindObjectOfType<FarmManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //fc.openTileMenu(this);
        Debug.Log("Clicked");
    }
}
