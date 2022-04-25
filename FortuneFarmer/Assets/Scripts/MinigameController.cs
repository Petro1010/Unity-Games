using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace FortuneFarmer
{
    public class MinigameController : MonoBehaviour
    {
        //Creating a singleton reference of MinigameController
        public static MinigameController instance;

        void Awake() {
            if (instance != null)
            {
                Debug.LogWarning("Error! Attempting to make more than one instance of Minigame Controller");
                return;
            }
            instance = this;
        }
        // class variables
        private int coins;
        private List<Item> inventory;
        private string lastScene;

        //for catch apple game
        private CatchAppleInfo catchApple;
        public GameObject gameOverText;
        public GameObject exitButton;
        public GameObject tryAgainButton;

        //for guessing game
        private GuessGameInfo guessGame;
        private int randomNum;
        public TMP_InputField guessText;
        public Text guessNotify;
        public TMP_Text endGameText;
        public GameObject guessButton;
        public GameObject exitButton2;
        public GameObject tryAgainButton2;


        [SerializeField] private TextMeshProUGUI CoinBalance;

        // Start is called before the first frame update
        void Start()
        {
            //GameController.instance.Start();
            this.DisplayMinigameInfo();
            catchApple = this.gameObject.transform.GetChild(2).GetComponent<CatchAppleInfo>();
            guessGame = this.gameObject.transform.GetChild(3).GetComponent<GuessGameInfo>();
        }

        void FixedUpdate()
        {
            if (catchApple.activeGame){  //deals with movement of player only for catch apple game
                float h = Input.GetAxisRaw("Horizontal");

                if (h > 0){
                    catchApple.player.velocity = Vector2.right*catchApple.playerSpeed;  //move right
                }
                else if (h < 0){
                    catchApple.player.velocity = Vector2.left*catchApple.playerSpeed;  //move left
                }
                else{
                    catchApple.player.velocity = Vector2.zero;  //stay in place
                }

                catchApple.player.transform.position = new Vector2(Mathf.Clamp(catchApple.player.transform.position.x, 
                -catchApple.xBounds, catchApple.xBounds), catchApple.player.transform.position.y);


            }
        }

        public void StartMinigame(string miniGame)
        {
            if (miniGame == "catchApple"){  //Sets a specific minigame to be currently active
                catchApple.setActive(true);
                StartCoroutine(SpawnRandomGameObject());  //start spawning the falling objects
            }

            if (miniGame == "guess"){
                guessGame.setActive(true);
                randomNum = guessGame.getRandNum();
            }
        }

        public void updateScore(){
            catchApple.updateScore();
        }

        public void updateMisses(){
            catchApple.updateMisses();
            if (catchApple.misses >= 5){
                this.GameOver();
            }
        }

        public void makeGuess(){
            string guess = guessText.text;
            int guessInt = System.Convert.ToInt32(guess);
            if (guessInt > 100 || guessInt < 1){   //invalid guess made
                guessNotify.text = "Invalid";
            }
            else{
                guessGame.makeGuess();  //valid guess, up the guess counter

                if (guessInt > randomNum){
                    guessNotify.text = "Lower";
                }
                else if (guessInt < randomNum){
                    guessNotify.text = "Higher";
                }
                else{
                    guessNotify.text = guess;
                    guessGame.WonGame();
                    this.GameOver();
                }

                if (guessGame.guesses >= 5){ //made 5 guesses, game over
                    this.GameOver();
                }
            }
        }

        public void GameOver(){
            if (catchApple.activeGame){
                coins += catchApple.score;  //trying to update coins
                this.UpdateMinigameInfo();
                this.DisplayMinigameInfo();
                catchApple.setActive(false);
                gameOverText.SetActive(true);
                exitButton.SetActive(true);
                tryAgainButton.SetActive(true);
                catchApple.resetGame();
            }

            if (guessGame.activeGame){
                guessGame.setActive(false);
                guessText.gameObject.SetActive(false);
                guessButton.SetActive(false);

                if (guessGame.getWon()){
                    endGameText.text = "You Won!";
                    coins += guessGame.prize;  //trying to update coins
                    this.UpdateMinigameInfo();
                    this.DisplayMinigameInfo();
                }
                else{
                    endGameText.text = "You Lost! Correct number was " + randomNum;
                }
                exitButton2.SetActive(true);
                tryAgainButton2.SetActive(true);
                endGameText.gameObject.SetActive(true);
                guessGame.resetGame();
            }
            

        }

        public void DisplayMinigameInfo()
        {
            (coins, inventory) = GameController.instance.getInventoryData();
            lastScene = GameController.instance.getGameStatusData();

            CoinBalance.text = $"Coins: {coins}";
        }

        public void UpdateMinigameInfo()
        {
            //Debug.Log(coins);
            GameController.instance.updatePlayerSaveData(coins, inventory);
            GameController.instance.updatePlayerSaveData(lastScene);
        }

        public void GoToMap()
        {
            lastScene = SceneManager.GetActiveScene().name;
            this.UpdateMinigameInfo();
            SceneManager.LoadScene("MapUI");
        }

        public void GoToSettings()
        {
            lastScene = SceneManager.GetActiveScene().name;
            this.UpdateMinigameInfo();
            SceneManager.LoadScene("SettingsUI");
        }

        IEnumerator SpawnRandomGameObject()
        {
            
            yield return new WaitForSeconds(Random.Range(1,2));  //time between objects falling

            if (Random.value < .7f){
                Instantiate(catchApple.apple, 
                new Vector2(Random.Range(-catchApple.xBounds, catchApple.xBounds), catchApple.yBounds), Quaternion.identity);
            }
            else{
                Instantiate(catchApple.rock, 
                new Vector2(Random.Range(-catchApple.xBounds, catchApple.xBounds), catchApple.yBounds), Quaternion.identity);
            }

            if (catchApple.activeGame){  //only keep spawning if game is active
                StartCoroutine(SpawnRandomGameObject());
            }
            
            
            
        }
    }
}

