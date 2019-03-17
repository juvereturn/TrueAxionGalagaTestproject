using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script checks the type of enemy, then call its own attack state
/// </summary>

public class StateAttack : State
{
    public StateAttack(EnemyAgent enemy)
    {
        this.Enemy_Agent = enemy;
    }

    public override void OnEntry()
    {
        //if the target is null or inactive, skip attack and go to "GoBackToSpot" state
        if (Enemy_Agent.target == null || !Enemy_Agent.target.activeSelf)
        {
            Enemy_Agent.currentState = new StateGoBackToSpot(Enemy_Agent);
        }

        //Each kind of enemy has its own attack, therefore I use casting for checking the type of enemy 
        BlueEnemyAgent b = Enemy_Agent as BlueEnemyAgent;
        if (b != null)
        {
            Enemy_Agent.currentState = new StateBlueAttack(Enemy_Agent);
        }

        RedEnemyAgent r = Enemy_Agent as RedEnemyAgent;
        if (r != null)
        {
            Enemy_Agent.currentState = new StateRedAttack(Enemy_Agent);
        }

        GreenEnemyAgent g = Enemy_Agent as GreenEnemyAgent;
        if (g != null)
        {
            Enemy_Agent.currentState = new StateGreenAttack(Enemy_Agent);
        }
    }

    public override void OnState()
    {
        
    }

    public override void OnExit()
    {

    }
}
