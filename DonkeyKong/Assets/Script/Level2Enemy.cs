using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefabs;
    [SerializeField] Transform enemySpawnPos;
    [SerializeField] bool canSpawn = true;
    private Animator animator;
    public int spawnCount = 0;

    private void Update()
    {
        
        Invoke("StartEnemySpawner", 2);
        Invoke("StopEnemySpawner", 5);
    }
    public void StartEnemySpawner()
    {
        if (spawnCount < 2 && canSpawn)
        {
            canSpawn = false;
            spawnCount++;
            Instantiate(enemyPrefabs, enemySpawnPos.position, Quaternion.identity);
        }
    }
    public void StopEnemySpawner()
    {
        canSpawn=true;
    }
}
