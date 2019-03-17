using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script store the fundamental attribute of enemy and instantiate "State" or its behavior
/// </summary>

public class EnemyAgent : MonoBehaviour
{
    [Tooltip("Score that player gains after killing this enemy")]
    public int scorePoint = 0;

    [Tooltip("move speed of this enemy when attacking")]
    public float speed = 6;

    [HideInInspector]public GameManager gameManager;
    [HideInInspector]public GameObject target;
    public GameObject explosionParticle;

    //use to store the current state or behavior of the enemy
    private State _currentState;
    public State currentState
    {
        get { return _currentState; }
        set
        {
            if (_currentState != null)
            {
                _currentState.OnExit();
            }
            _currentState = value;
            _currentState.OnEntry();
        }
    }

    // Set the dafault state to idle
    public virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        target = GameObject.FindGameObjectWithTag("Player");
        currentState = new StateIdle(this);
    }

    //Update the current state of the enemy
    public virtual void Update()
    {
        currentState.OnState();
    }

    //If the enemy is collided with player's projectile: increase the scare, create the explosion particle, and destroy this object
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerProjectile")
        {
            gameManager.IncreaseScore(scorePoint);
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            if (gameManager.enemyAttackController.enemyList.Contains(this))
            {
                gameManager.enemyAttackController.enemyList.Remove(this);
            }
            Destroy(gameObject);
        }
    }
}
