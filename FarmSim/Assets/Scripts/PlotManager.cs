using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{

    bool isPlanted = false;
    SpriteRenderer plant;
    BoxCollider2D plantCollider;  //gets the collider of the current plant form (different forms will have different hit boxes)

    int plantStage = 0;  //records what stage the plant is at
    float timer;

    PlantObjectScript selectedPlant;  //will give us the information about the specific plant, public so programmer can enter it directly

    FarmManager fm;

    public Color availColor = Color.green;
    public Color unavailColor = Color.red;
    SpriteRenderer plot;

    bool isDry = true;
    public Sprite drySprite;
    public Sprite normalSprite;
    public Sprite unavailable;

    float speed = 1f;  //speed at which plant grows, adding fertilizer will increase this

    public bool isBought = true;  //is the plot available or not

    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider= transform.GetChild(0).GetComponent<BoxCollider2D>();
        fm = transform.parent.GetComponent<FarmManager>();
        plot = GetComponent<SpriteRenderer>();
        if (!isBought){
            plot.sprite = unavailable;
        }
        else{
            plot.sprite = drySprite;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if(isPlanted && !isDry){  //plant only grows if its not dry
            timer -= speed*Time.deltaTime;  //speed will make timer fall faster
            if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1){  //if the timer is up and we are not on the final stage, update
                timer = selectedPlant.timeBtwnStages;
                plantStage++;
                UpdatePlant();
            }
        }
        
    }

    private void OnMouseDown()
    {
        if(isPlanted)    
        {
            if (plantStage == selectedPlant.plantStages.Length - 1 && !fm.isPlanting && !fm.isUseTool){ //when u click the mouse down, if something is planted and at its final stage and not trying to plant something it will harvest it
                Harvest();
            }
            
        }
        else if(fm.isPlanting && fm.selectPlant.plant.buyPrice <= fm.money && isBought){
            Plant(fm.selectPlant.plant);  //refereencing the farm manager which has the selected plant
        }
        //Debug.Log("Clicked");

        if (fm.isUseTool){
            switch (fm.selectedTool){
                case 1:
                    if (isBought){
                        isDry = false;
                        plot.sprite = normalSprite;
                        if (isPlanted){
                            UpdatePlant();
                        }
                    }
                    break;
                case 2:
                    if (fm.money >= 10 && isBought){
                        fm.Transaction(-10);
                        if (speed < 2){
                            speed += 0.2f;
                        }
                    }
                    
                    break;
                case 3:
                    if (fm.money >= 100 && !isBought){
                        fm.Transaction(-100);
                        isBought = true;
                        plot.sprite = drySprite;

                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void OnMouseOver(){
        if (fm.isPlanting){
            if(isPlanted || fm.selectPlant.plant.buyPrice > fm.money || !isBought){
                //cant buy
                plot.color = unavailColor;

            }
            else{
                //can buy
                plot.color = availColor;

            }
        }
    }

    private void OnMouseExit(){
        plot.color = Color.white;
    }

    void Harvest(){  //harvesting involves making the plant not active
        //Debug.Log("Harvested");
        isPlanted = false;
        plant.gameObject.SetActive(false);  //deactivates the ingame object
        isDry = true;
        plot.sprite = drySprite;
        fm.Transaction(selectedPlant.sellPrice);
        speed = 1f;
    }

    void Plant(PlantObjectScript newPlant){  //planting involves making the plant now active
        //Debug.Log("Planted");
        
        selectedPlant = newPlant;
        isPlanted = true;

        fm.Transaction(-selectedPlant.buyPrice);
        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwnStages;  //reset timer to 2 seconds
        plant.gameObject.SetActive(true);  //activates the ingame object

    }

    void UpdatePlant(){
        if (isDry){
            plant.sprite = selectedPlant.dryPlant;
        }
        else{
            plant.sprite = selectedPlant.plantStages[plantStage]; //update plant to next stage
        }
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, plant.bounds.size.y/2);  //this will update the hitbox of our harvestable plant

    }
}
