using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Blue Attack AI where it can't shoot and attack by moving to player's position
/// </summary>

public class StateBlueAttack : State
{
    //the target will be the player
    private GameObject target;

    //Use For storing the position of player at the moment when it starts attacking
    Vector3 instantTarget;

    //min and max of viewport for checking if the enemy is off-screen 
    Vector2 minViewport;
    Vector2 maxViewport;

    public StateBlueAttack(EnemyAgent AI)
    {
        this.Enemy_Agent = AI;
        target = Enemy_Agent.target;
    }

    // store player's position as an "instantTarget"
    public override void OnEntry()
    {
        minViewport = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxViewport = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        instantTarget = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
    }

    public override void OnState()
    {
        rotateToTarget();
        moveForward();

        //if it moves out of the bottom go to "StateGoBackToSpot"
        if (Enemy_Agent.transform.position.y < minViewport.y)
        {
            Enemy_Agent.currentState = new StateGoBackToSpot(Enemy_Agent);
        }
    }

    //move it to top of the screen and set its rotation to the original 
    public override void OnExit()
    {
        Enemy_Agent.transform.position = new Vector3(Enemy_Agent.transform.position.x, maxViewport.y, Enemy_Agent.transform.position.z);
        Enemy_Agent.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }

    //Rotate the upward vector(y position) to the target
    public void rotateToTarget()
    {
        float angle = Mathf.Rad2Deg * (Mathf.Atan((instantTarget.x - Enemy_Agent.transform.position.x) / (instantTarget.y - Enemy_Agent.transform.position.y)));
        Enemy_Agent.transform.eulerAngles = new Vector3(0.0f, 0.0f, 180 - angle);
    }

    //Transform the enemy according to up vector
    public void moveForward()
    {
        Enemy_Agent.transform.position += Enemy_Agent.transform.up * Enemy_Agent.speed * Time.deltaTime;
    }

    
}
