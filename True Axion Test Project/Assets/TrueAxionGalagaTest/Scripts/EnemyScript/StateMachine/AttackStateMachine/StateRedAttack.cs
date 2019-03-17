using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Red Attack AI where it attacks by flying above Player position and shooting energy beam
/// </summary>

public class StateRedAttack : StateProjectileAttack
{
    //Use for casting AIagent to RedEnemyAgent
    RedEnemyAgent redEnemy_Agent;

    public StateRedAttack(EnemyAgent enemy) : base(enemy)
    {
        redEnemy_Agent = Enemy_Agent as RedEnemyAgent;
        redEnemy_Agent.ammo = redEnemy_Agent.maxRocketsAmount;
        nextFire = redEnemy_Agent.fireRate;
    }

    public override void OnEntry()
    {
        beginAttacking = false;
    }

    public override void OnState()
    {
        //In case that player dies with the projectile, go to "StateGoBackToSpot" immediately
        if (Enemy_Agent.target == null || !Enemy_Agent.target.activeSelf)
        {
            Enemy_Agent.currentState = new StateGoBackToSpot(Enemy_Agent);
        }

        //Before attacking, it will movetoward player position until it closes enought to player's position
        if (beginAttacking == false)
        {
            Vector3 targetDirection = Enemy_Agent.target.transform.position - Enemy_Agent.transform.position;
            if (targetDirection.sqrMagnitude >= closeEnoughDistanceToShoot)
            {
                SeekTarget(Enemy_Agent.target.transform);
            }
            else
            {
                beginAttacking = true;
            }
            
        }
        //if it closes enough then it will shoot until the ammo runs out
        else
        {
            if (redEnemy_Agent.ammo > 0)
            {
                Shoot();
            }
            else
            {
                WaitAndGoBackToSpot();
            }
        }
    }


    public override void OnExit()
    {
        
    }

    
}
