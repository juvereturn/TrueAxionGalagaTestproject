using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This script keeps track of game state and update UI
/// </summary>


public class GameManager : MonoBehaviour
{

    //score that player gain, I use static, so that the score won't reset when the game reload scene
    static int score = 0;

    //All  GUIs in the game
    public Text scoreText;
    public Text livesText;
    public GameObject GameOverUI;

    [Tooltip("Player In The Game")]
    public PlayerController activePlayer;

    [Tooltip("Enemy Controller's Component")]
    public EnemyAttackController enemyAttackController;

    //these variables are used on waitAndRespawn() to make the player's character doesn't revive immediately
    public float recallAttackTimeCount = 3.0f;
    float currentRespawntime = 0.0f;

    //track the game over state
    bool gameOver = false;

    void Start()
    {

    }

    void Update()
    {
        UpdateUIText();
        CheckGameState();
    }

    //Convert int to string in order to assign  it to text
    public void UpdateUIText()
    {
        scoreText.text = score.ToString();
        livesText.text = activePlayer.lives.ToString();
    }

    void CheckGameState()
    {
        if (enemyAttackController.enemyList.Count <= 0) //If all enemies are killed, load the scene and continue playing
        {
            SceneManager.LoadScene("GameScene");
        }

        if (activePlayer.GetIsKilled())//if the player is killed
        {
            if (gameOver == true)//If the game is over, you can press “spacebar” to restart the game and the score will reset.
            {
                if (Input.GetKeyDown("space"))
                {
                    score = 0;
                    SceneManager.LoadScene("GameScene");
                }
            }
            else // if the game isn't over yet, player will wait for "recallAttackTimeCount" seconds, then player will respawn
            {
                WaitAndRespawnPlayer();
            }
        }

    }

    //wait for "recallAttackTimeCount" seconds, then player will become active
    void WaitAndRespawnPlayer()
    {

        currentRespawntime += Time.deltaTime;
        if (currentRespawntime > recallAttackTimeCount)
        {
            activePlayer.gameObject.SetActive(true);
            //set the boolean "isKilled" to false, then set the revert the respawn time
            activePlayer.SetIsKilled(false);
            currentRespawntime = 0.0f;
        }
    }

    //If the gam is over, the game over UI will appear as well
    public void SetGameOver(bool gameOverSet)
    {
        gameOver = gameOverSet;
        GameOverUI.SetActive(gameOver);
    }

    //Increase score according to increaseAmount
    public void IncreaseScore(int increaseAmount)
    {
        score += increaseAmount;
    }


}
