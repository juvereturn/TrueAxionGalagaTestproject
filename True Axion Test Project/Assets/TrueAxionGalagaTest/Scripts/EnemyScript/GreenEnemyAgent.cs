using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemyAgent : EnemyProjectileAgent
{
    // Unlike other enemies, this one will target player
    public override void Start()
    {
        base.Start();
        target = GameObject.Find("AbovePlayerPosition");
        ammo = 1;
    }

    void Update()
    {
        base.Update();
    }
}
