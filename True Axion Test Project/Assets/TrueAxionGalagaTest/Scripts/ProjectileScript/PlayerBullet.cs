using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Projectile
{
    // The move direction enemy is originally set to (0f, 1f, 0f), because players will only shoot up
    void Start()
    {
        moveDirection = new Vector3(0f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    //Destroy When it hits enemy
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
