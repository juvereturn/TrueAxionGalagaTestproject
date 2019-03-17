using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyAgent : EnemyProjectileAgent
{
    [Tooltip("Amount of rockets that it can shoot")]
    public int maxRocketsAmount;
    [HideInInspector]public int currentRocketAmount;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        ammo = maxRocketsAmount;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
