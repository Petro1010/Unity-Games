using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName= "Plant")]  //This will give us the option to create the asset directly from the menu
public class PlantObjectScript : ScriptableObject  //these objects will store the data realting to a plant
{
    //These will be the parameters to be filled by the object
    public Sprite[] plantStages; //keep all the plant stages in one array
    public float timeBtwnStages; //growth time in seconds
    public string plantName; 
    public int buyPrice;
    public int sellPrice;
    public Sprite icon;
    public Sprite dryPlant;

}
