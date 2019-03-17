using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script calls a member of enemies to attack player
/// </summary>

public class EnemyAttackController : MonoBehaviour
{
    //list that store all enemies
    [HideInInspector]public List<EnemyAgent> enemyList;

    [Tooltip("spawn frequency. the higher the more frequent")]
    public float callAttackRate = 2.0f;
    float callAttackTime = 0.0f;
    float callAttackCount = 0.0f;

    [HideInInspector]
    public GameObject targetPlayer;

    void Start()
    {
        foreach (EnemyAgent enemy in FindObjectsOfType<EnemyAgent>())
        {
            enemyList.Add(enemy);
        }

        targetPlayer = GameObject.FindGameObjectWithTag("Player");

        callAttackTime = callAttackRate;
    }

    void Update()
    {
        ControlAttack();
    }

    void ControlAttack()
    {
        //if there's a player call the enemy to attack
        if (targetPlayer != null && targetPlayer.activeSelf)
        {
            CallEnemyToAttack();
        }
    }

    //call enemy to attack according to callAttackRate
    void CallEnemyToAttack() {
        //Add callAttackCount
        callAttackCount += Time.deltaTime;

        //callAttackCount exceeds callAttackTime: A Condition That Prevent Enemy From calling attack Rapidly
        if (callAttackCount > callAttackTime)
        {
            if (enemyList.Count > 0)
            {
                int randomRange = Random.Range(0, enemyList.Count - 1);
                enemyList[randomRange].currentState = new StateAttack(enemyList[randomRange]);
            }

            //Reset CallAttack CoolDown
            callAttackTime = callAttackRate;
            callAttackCount = 0.0f;
        }
    }

}
