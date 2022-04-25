using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuessGameInfo : MonoBehaviour
{

    private int randomNum;
    private bool Win;
    public bool activeGame = false;
    public int guesses;
    public TMP_Text guessText;
    public int prize = 25;

    public void setActive(bool active){
        activeGame = active;
        if (activeGame){
            randomNum = Random.Range(1, 101);
        }
    }

    public int getRandNum(){
        return randomNum;
    }

    public void makeGuess(){
        guesses++;
        guessText.text = "Guesses: " + guesses;
    }

    public void WonGame(){
        Win = true;
    }

    public bool getWon(){
        return Win;
    }

    public void resetGame(){
        guesses = 0;
        Win = false;
        guessText.text = "Guesses: ";
    }
}
