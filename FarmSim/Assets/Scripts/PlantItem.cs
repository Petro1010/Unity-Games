using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObjectScript plant;

    public Text nameTxt;
    public Text priceTxt;
    public Image icon;

    public Image btnImage;
    public Text btnText;

    FarmManager fm;
    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
        InitializeUI();
    }

    public void BuyPlant(){
        fm.SelectPlant(this);
    }

    void InitializeUI(){
        nameTxt.text = plant.plantName;
        priceTxt.text = "$" + plant.buyPrice;
        icon.sprite = plant.icon;
    }
}
