using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script spawns enemies according to 2d char array
/// </summary>

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("input vector3 for the first position to spawn")]
    public Vector3 firstPositionToSpawn;

    //Use 2d char array for storing the spawning enemy data
     /*
     n - don't spawn anything
     g - spawn green enemy
     r - spawn red enemy
     b - spawn blue enemy
     */
    char[,] spawnArray = new char[5, 10]{ { 'n', 'n', 'n', 'g', 'g', 'g', 'g', 'n', 'n', 'n'},
                                        { 'n', 'r', 'r', 'r', 'r', 'r', 'r', 'r', 'r', 'n'},
                                        { 'n', 'r', 'r', 'r', 'r', 'r', 'r', 'r', 'r', 'n'},
                                         { 'n', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'n'},
                                        { 'n', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'n'}};

    
    public float spaceBetweenSpawningX = 0.5f;
    public float spaceBetweenSpawningY = 0.5f;

    public GameObject spot;

    public GameObject RedEnemy;
    public GameObject BlueEnemy;
    public GameObject GreenEnemy;
    

    void Awake()
    {
        SpawnEnemies();
    }

    void Update()
    {
        
    }

    //spawn the enemies and move xy spawn position
    void SpawnEnemies()
    {
        Vector3 currentSpawnPosition = firstPositionToSpawn;

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 10; j++)
            {
                if (spawnArray[i, j] != 'n') {
                    GameObject Spot = Instantiate(spot, currentSpawnPosition, Quaternion.identity, this.gameObject.transform);
                    switch (spawnArray[i, j])
                    {
                        case 'g':
                            Instantiate(GreenEnemy, currentSpawnPosition, Quaternion.identity, Spot.transform);
                            break;
                        case 'r':
                            Instantiate(RedEnemy, currentSpawnPosition, Quaternion.identity, Spot.transform);
                            break;
                        case 'b':
                            Instantiate(BlueEnemy, currentSpawnPosition, Quaternion.identity, Spot.transform);
                            break;
                        dafault:
                            break;
                    }
                }
                currentSpawnPosition.x += spaceBetweenSpawningX;
            }
            currentSpawnPosition.x = firstPositionToSpawn.x;
            currentSpawnPosition.y -= spaceBetweenSpawningY;
        }
    }


}
