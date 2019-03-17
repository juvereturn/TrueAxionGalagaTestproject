using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script moves the enemy back to its spot where its belong
/// </summary>

public class StateGoBackToSpot : State
{
    private float closeEnoughDistanceToSpot = 0.1f;

    Vector2 minViewport;
    Vector2 maxViewport;

    public StateGoBackToSpot(EnemyAgent enemy)
    {
        this.Enemy_Agent = enemy;
    }

    public override void OnEntry()
    {
        minViewport = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxViewport = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    public override void OnState()
    {
        //if the enemy is below the middle screen go down until it reaches botton, then move it up to top of screen
        if (Enemy_Agent.transform.position.y <= 0.0f)
        {
            //GoDown
            Vector3 position = Enemy_Agent.transform.position;
            position = new Vector3(position.x, position.y - Enemy_Agent.speed * Time.deltaTime, position.z);
            Enemy_Agent.transform.position = position;

            if (Enemy_Agent.transform.position.y < minViewport.y)
            {
                Enemy_Agent.transform.position = new Vector3(position.x, maxViewport.y, position.z);
            }
        }
        //If the enemy is above the middle screen, move it toward its own spot
        else {
            //GoToSpot
            Transform spotPosition = Enemy_Agent.transform.parent;

            Vector3 targetDirection = spotPosition.position - Enemy_Agent.transform.position;

            if (targetDirection.sqrMagnitude >= closeEnoughDistanceToSpot)
            {
                SeekTarget(spotPosition);
            }
            else
            {
                Enemy_Agent.currentState = new StateIdle(Enemy_Agent);
            }
        }

    }

    public override void OnExit()
    {

    }

    //Move toward target
    public void SeekTarget(Transform target)
    {
        Vector3 position = Enemy_Agent.transform.position;
        Vector3 targetDirection = target.position - Enemy_Agent.transform.position;
        Vector3 desireVelocity = Vector3.Normalize(targetDirection) * Enemy_Agent.speed;

        position += desireVelocity * Time.deltaTime;
        Enemy_Agent.transform.position = position;
    }
}
