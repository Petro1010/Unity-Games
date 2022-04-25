using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will load all the plant resources into the store at once
public class StoreManager : MonoBehaviour
{
    public GameObject plantItem;
    List<PlantObjectScript> plantObs = new List<PlantObjectScript>();

    private void Awake(){
        //Assets/Resources/Plants folder. This is where we will have the plantItems that we want to be built
        var loadPlants = Resources.LoadAll("Plants", typeof(PlantObjectScript));
        foreach(var plant in loadPlants){

            plantObs.Add((PlantObjectScript)plant);

            //This code is for when order does not matter, we want it sorted however
            //PlantItem newPlant = Instantiate(plantItem, transform).GetComponent<PlantItem>();
            //newPlant.plant = (PlantObjectScript)plant;
        }

        plantObs.Sort(SortByPrice);
        //now instantiate in that order
        foreach(var plant in plantObs){
            PlantItem newPlant = Instantiate(plantItem, transform).GetComponent<PlantItem>();
            newPlant.plant = plant;
        }
    }

    //Sorting them by price
    int SortByPrice(PlantObjectScript plantOb, PlantObjectScript plantOb2){
        return plantOb.buyPrice.CompareTo(plantOb2.buyPrice);

    }
}
