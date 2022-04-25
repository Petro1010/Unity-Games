using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchAppleInfo : MonoBehaviour
{
    public Rigidbody2D player;
    public float playerSpeed;
    public string description = "";
    public int prize;
    public bool activeGame = false;
    public float xBounds;
    public float yBounds;
    public GameObject apple;
    public GameObject rock;
    public int score;
    public int misses;
    public Text scoreText;
    public Text missText;



    void Start()
    {
        player = transform.GetChild(2).GetComponent<Rigidbody2D>();
    }

    public void setActive(bool active){
        activeGame = active;
    }

    public void updateScore(){
        if (activeGame){
            score++;
            scoreText.text = "Score: " + score;
        }
        
    }

    public void updateMisses(){
        if (activeGame){
            misses++;
            missText.text = "Misses: " + misses;
        }
        
    }

    public void resetGame(){
        score = 0;
        misses = 0;
        missText.text = "Misses: ";
        scoreText.text = "Score: ";
    }
}
