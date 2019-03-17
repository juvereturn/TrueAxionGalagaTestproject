using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : EnemyBullet
{

    [HideInInspector]public GameObject target;

    //Use For storing the position of player at the moment when the rocket is spawned
    Vector3 instantTarget;

    // Find player, and store player's position as an "instantTarget"
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            instantTarget = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        }
        
    }

    // After rotation, the rocket will move toward the player's position
    void Update()
    {
        RotateToTarget();
        base.Update();
    }

    //Rotate the upward vector(y position) to the target
    public void RotateToTarget()
    {
        float angle = Mathf.Rad2Deg * (Mathf.Atan((instantTarget.x - transform.position.x)/(instantTarget.y - transform.position.y) ));
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 180 - angle);
        moveDirection = transform.up;
    }

}
