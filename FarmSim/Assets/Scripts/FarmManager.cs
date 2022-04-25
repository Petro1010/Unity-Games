using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public PlantItem selectPlant;
    public bool isPlanting = false;  //tells us whether we have selected a plant to place or not
    public int money = 100;
    public Text moneyText;

    public Color buyColor = Color.green;
    public Color cancelColor = Color.red;

    public bool isUseTool = false;  //tracks if a tool is selected or not
    public int selectedTool;  //keeps track of the tool being used, 1 is water, 2 is fert, 3 is plot

    public Image[] buttonsImg;
    public Sprite normalButton;
    public Sprite selectedButton;

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "$" + money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectPlant(PlantItem plant){
        if (selectPlant == plant){
            selectPlant.btnImage.color = buyColor;
            selectPlant.btnText.text = "Buy";
            selectPlant = null;
            isPlanting = false;
        }
        else{
            CheckSelection();
            selectPlant = plant;
            selectPlant.btnImage.color = cancelColor;
            selectPlant.btnText.text = "Cancel";
            isPlanting = true;
        }

    }

    public void SelectTool(int tool){
        if (tool == selectedTool){
            //deselect
            CheckSelection();
        }
        else{
            //select tool number and make sure all others plants/tools are deselected
            CheckSelection();
            isUseTool = true;
            selectedTool = tool;
            buttonsImg[tool - 1].sprite = selectedButton;
        }
    }

    public void Transaction(int value){
        money += value;
        moneyText.text = "$" + money;

    }

    void CheckSelection(){
        //deselect any currently selected plants
        if (isPlanting){
            isPlanting = false;
            if(selectPlant != null){  //deals with the case where we were just buying a previous plant and didnt deselect it
                selectPlant.btnImage.color = buyColor;
                selectPlant.btnText.text = "Buy";
            }
            selectPlant = null;
        }
        //deselect any current tools
        if (isUseTool){
            if (selectedTool > 0){
                buttonsImg[selectedTool - 1].sprite = normalButton;
            }   
            isUseTool = false;
            selectedTool = 0;
        }
    }
}
