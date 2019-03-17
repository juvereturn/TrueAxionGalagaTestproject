using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script control player's movment and store the attrubute of player
/// </summary>

public class PlayerController : MonoBehaviour
{
    [Tooltip("Total Lives Of PLayer")]
    public int lives = 3;

    [Tooltip("Movement Speed Of Player")]
    public float speed = 3.0f;

    //The state that checks if the player is killed or not
    bool isKilled = false;

    //Game Manager Component needed for updating lives and score UI
    [HideInInspector]public GameManager GM;

    [Tooltip("Store the above position of player")]
    public GameObject abovePlayerPosition;

    //min and max of viewport for checking if the player is off-screen 
    Vector2 minViewport;
    Vector2 maxViewport;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();

        //Restric Area That Players Can Go
        minViewport = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxViewport = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
       
        //Calculate position after move from input horizontal axis
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 pos = transform.position;
        pos += new Vector2(x * speed * Time.deltaTime, 0.0f);

        //Restrict Area That Players Can Go
        pos.x = Mathf.Clamp(pos.x, minViewport.x, maxViewport.x);

        //Apply calculated position
        transform.position = pos;
    }

    //decrease a life and set player to inactive
    public void DecreaseLifeAndKillPlayer()
    {
        if (lives > 0)
        {
            lives--;
            isKilled = true;
            gameObject.SetActive(false);

            //If lives is less than , call game manager and set "gameOver" to true
            if (lives <= 0)
            {
                GM.SetGameOver(true);
            }
        }

    }

    public bool GetIsKilled()
    {
        return isKilled;
    }

    public void SetIsKilled(bool kill)
    {
        isKilled = kill;
    }

    //Decrease a life and destroy the character, when the projectile or enemy is hit
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" || col.tag == "EnemyProjectile")
        {
            DecreaseLifeAndKillPlayer();
        }
    }
}
