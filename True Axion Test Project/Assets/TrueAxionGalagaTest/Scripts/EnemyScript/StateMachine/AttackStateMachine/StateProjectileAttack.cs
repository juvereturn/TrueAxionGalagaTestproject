using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateProjectileAttack : State
{
    EnemyProjectileAgent enemyProjectile_Agent;

    //Use to keep track the projectile cooldown
    protected float nextFire = 1.0f;
    protected float currentFireCount = 0.0f;

    //Use to keep track of the time before going to "StateGoBackToSpot"
    protected float waitTime = 0.5f;
    protected float currentWaitTimeCount = 0.0f;

    //Use to keep track the enemy state
    protected bool beginAttacking = false;
    protected float closeEnoughDistanceToShoot = 5.0f;

    public StateProjectileAttack(EnemyAgent enemy) : base(enemy)
    {
        enemyProjectile_Agent = Enemy_Agent as EnemyProjectileAgent;
    }

    public override void OnEntry()
    {
        
    }

    public override void OnState()
    {
       
    }


    public override void OnExit()
    {

    }

    //Move toward the target
    public void SeekTarget(Transform target)
    {
        Vector3 position = Enemy_Agent.transform.position;
        Vector3 targetDirection = target.position - Enemy_Agent.transform.position;
        Vector3 desireVelocity = Vector3.Normalize(targetDirection) * Enemy_Agent.speed;

        position += desireVelocity * Time.deltaTime;
        Enemy_Agent.transform.position = position;
    }

    //Wait for a short time, then it will return to the spot
    public void WaitAndGoBackToSpot()
    {
        //Add Time to currentWaitTimeCount
        currentWaitTimeCount += Time.deltaTime;

        if (currentWaitTimeCount > waitTime)
        {
            //Reset The WaitTime
            waitTime = 0.5f;
            currentWaitTimeCount = 0.0f;

            //Go To "StateGoBackToSpot"
            Enemy_Agent.currentState = new StateGoBackToSpot(Enemy_Agent);
        }
    }

    public void Shoot()
    {
        //Add Time to currentFireCount
        currentFireCount += Time.deltaTime;

        //callAttackCount > nextFire: A Condition That Prevent the Enemy From Shooting Rapidly
        if (currentFireCount > nextFire)
        {

            //SpawnProjectile
            enemyProjectile_Agent.SpawnBullet();
            enemyProjectile_Agent.ammo--;

            //Reset The CoolDown Time(Make The Enemy Able To Shoot Again)
            nextFire = enemyProjectile_Agent.fireRate;
            currentFireCount = 0.0f;
        }
    }
}
