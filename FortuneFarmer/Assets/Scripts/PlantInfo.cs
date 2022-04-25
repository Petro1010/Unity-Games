using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName= "Plant")]  //This will give us the option to create the asset directly from the menu
public class PlantInfo : Item
{
    public Sprite[] plantStages; //keep all the plant stages in one array
    public float timeBtwnStages; //growth time in seconds
    public float growthMultiplier;
    public int currentStage;
    public Sprite dryPlant;

}
