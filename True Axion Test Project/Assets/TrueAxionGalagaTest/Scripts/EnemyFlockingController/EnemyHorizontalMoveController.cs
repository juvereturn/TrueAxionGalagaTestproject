using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Move a flock of spot(where enemy resides) to left and to right
/// </summary>

public class EnemyHorizontalMoveController : MonoBehaviour
{
    [Tooltip("The distance that enemy will transform on X axis")]
    public float HorizontalTransfromAmount = 0.25f;

    //list of spot(where enemies stay before attack)
    GameObject [] spotList;

    //Use to track where it's left or right direction that
    bool goLeft = true;

    //min and max of viewport for checking if the spot is off-screen 
    Vector2 minViewport;
    Vector2 maxViewport;


    void Start()
    {
        spotList = GameObject.FindGameObjectsWithTag("Spot");
        minViewport = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxViewport = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    
    void Update()
    {
        ControlHorizontalMove();
    }

    //Move the horde of spots(also move the enemies) to left or right until it reaches the border, then change the direction
    void ControlHorizontalMove()
    {
        foreach (GameObject spot in spotList)
        {
            if (goLeft == true)
            {
                spot.transform.position -= new Vector3(HorizontalTransfromAmount, 0.0f, 0.0f) * Time.deltaTime;
                if (spot.transform.position.x < minViewport.x)
                {
                    goLeft = false;
                }
            }
            else
            {
                spot.transform.position += new Vector3(HorizontalTransfromAmount, 0.0f, 0.0f) * Time.deltaTime;
                if (spot.transform.position.x > maxViewport.x)
                {
                    goLeft = true;
                }
            }

        }
    }
}
