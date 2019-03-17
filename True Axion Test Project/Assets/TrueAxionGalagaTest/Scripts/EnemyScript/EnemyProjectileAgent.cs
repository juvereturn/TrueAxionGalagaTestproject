using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script store attribute for only the enemies that can shoot
/// </summary>

public class EnemyProjectileAgent : EnemyAgent
{
    [Tooltip("Bullet Spawn Position")]
    public GameObject bulletSpawnPosition;

    [Tooltip("projectile prefab")]
    public GameObject projectile;

    [Tooltip("shooting frequency. the higher the more frequent")]
    public float fireRate = 1.0f;

    [HideInInspector]public int ammo;

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        base.Update();
    }

    //spawn bullet where it will be called in during StateAttack
    public void SpawnBullet() {
        Instantiate(projectile, bulletSpawnPosition.transform.position, Quaternion.identity);
    }
}
