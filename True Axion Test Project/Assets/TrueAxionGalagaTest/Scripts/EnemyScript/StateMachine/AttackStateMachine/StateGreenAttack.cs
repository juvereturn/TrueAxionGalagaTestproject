using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Green Attack AI where it attacks by flying near Player and shooting the rockets
/// </summary>

public class StateGreenAttack : StateProjectileAttack
{
    //Use for casting AIagent to GreenEnemyAgent
    GreenEnemyAgent greenEnemy_Agent;

    public StateGreenAttack(EnemyAgent enemy) :base(enemy)
    {
        greenEnemy_Agent = Enemy_Agent as GreenEnemyAgent;
        greenEnemy_Agent.ammo = 1;
        nextFire = greenEnemy_Agent.fireRate;
    }

    public override void OnEntry()
    {
        closeEnoughDistanceToShoot = 1.0f;
        beginAttacking = false;
    }

    public override void OnState()
    {
        //In case that player dies with the projectile, go to "StateGoBackToSpot" immediately
        if (Enemy_Agent.target == null || !Enemy_Agent.target.activeSelf)
        {
            Enemy_Agent.currentState = new StateGoBackToSpot(Enemy_Agent);
        }

        if (beginAttacking == false)
        {
            //Move toward the above of player until its close enough to shoot
            Vector3 targetDirection = Enemy_Agent.target.transform.position - Enemy_Agent.transform.position;
            
            if (targetDirection.sqrMagnitude >= closeEnoughDistanceToShoot)
            {
                SeekTarget(Enemy_Agent.target.transform);
            }
            else {
                beginAttacking = true;
            }
        } else {
            //if it closes enough then it will shoot until the ammo runs out
            if (greenEnemy_Agent.ammo > 0)
            {
                Shoot();
            }
            else {
                WaitAndGoBackToSpot();
            }
        }
    }

    //set begin attacking to false
    public override void OnExit()
    {
       
    }
}
