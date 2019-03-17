using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Tooltip("Where the bullet will spawn")]
    public Transform bulletSpawnPosition;

    [Tooltip("projectile prefab")]
    public GameObject playerBullet;

    [Tooltip("shooting frequency. the higher the more frequent")]
    public float fireRate = 1.0f;
    //Cooldown time for the next fire
    float nextFire = 0.0f;
    //keep track of the curren cooldown time
    float currentFireCount = 0.0f;

    void Start()
    {
        //Set Spawn Position With the current GameObject position, if there's no spawn position
        if (bulletSpawnPosition == null) {
            bulletSpawnPosition = this.gameObject.transform;
        }

    }

    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        //Add Time to currentFireCount
        currentFireCount += Time.deltaTime;

        //Check If Players Press Spacebar
        //callAttackCount > nextFire: A Condition That Prevent Player From Shooting Rapidly
        if (Input.GetButton("Fire1") && currentFireCount > nextFire)
        {
            //SpawnBullet
            Instantiate(playerBullet, bulletSpawnPosition.position, Quaternion.identity);

            //Reset The CoolDown Time(Make The Character Able To Shoot Again)
            nextFire = fireRate;
            currentFireCount = 0.0f;
        }
    }
}
