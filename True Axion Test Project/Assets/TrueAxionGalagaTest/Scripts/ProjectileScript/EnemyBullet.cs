using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Projectile
{
    // The move direction enemy is originally set to (0f, -1f, 0f), because the enemy will only shoot down
    void Start()
    {
        moveDirection = new Vector3(0f, -1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    //Destroy When it hits player
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
