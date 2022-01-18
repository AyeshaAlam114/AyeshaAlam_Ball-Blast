using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public GameObject gameOverPanel;
    public GameObject gamePlayPanel;

    public GameObject playerHealthStatus;
    public GameObject playerScoreStatus;

    public float gravityModifier;

    PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        SetGravity();
        gameOverPanel.SetActive(false);                                                                                     //game over pannel is off
        gamePlayPanel.SetActive(true);                                                                                      //game play pannel is on
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();                                   //get PlayerHealth component of player
        gameOver = false;                                                                                                   //boolean which checks if the game is in run state or over state
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealthStatus();                                                                                               //call to player's health status
    }

    public void SetGravity()
    {
        Physics.gravity *= gravityModifier;                                                                                 //modify the project's gravity for smoother bounce effect
    }

    public void GameOver()
    {
        gameOver = true;                                                                                                    //set boolean to over state          
        Time.timeScale = 0;                                                                                                 //Time is paused that it impacts that game is in over state
        gameOverPanel.SetActive(true);                                                                                      //game over pannel is on
    }

    public void Restart()
    {
        Time.timeScale = 1;                                                                                                //Time is set to 1 that it impacts that game is in running state
        SceneManager.LoadScene(0);                                                                                         //load the scene of 0 index in build settings
    }

    void PlayerHealthStatus()
    {
        playerHealthStatus.GetComponent<Image>().fillAmount = player.playerHealth / player.maxPlayerHealth;                 //set the img ratio according to player's health
        if (player.playerHealth < player.maxPlayerHealth / 2)                                                               //check if health is down by half or not
            playerHealthStatus.GetComponent<Image>().color = Color.red;                                                     //change the helath bar colour
    }

    int GetScoreInt()
    {
        return int.Parse(playerScoreStatus.GetComponent<Text>().text);                                                      //return the score by converting it into int
    }

    void SetScoreDisplay(int score)
    {
        playerScoreStatus.GetComponent<Text>().text = score.ToString();                                                     //convert int to string and store in score text field
    }
    public void ScoreIncreaser()
    {
        int scoreInc = GetScoreInt();                                                                                       //recieve score in int
        scoreInc++;                                                                                                         //apply increment
        SetScoreDisplay(scoreInc);                                                                                          //call to set score

    }


    public void AddScore()
    {
        ScoreIncreaser();                                                                                                   //call to score increaser
    }

}
