using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefabs;
    [SerializeField] Transform enemySpawnPos;
    [SerializeField] bool canSpawn = true;
    private Animator animator;
    public int spawnCount = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (LevelManagerMemo.instance.died)
        {
            spawnCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Barrel")||collision.gameObject.CompareTag("BlueBarrel")) && spawnCount <2 && canSpawn)
        {
            spawnCount++;
            animator.Play("BurningBarrels");
            Instantiate(enemyPrefabs, enemySpawnPos.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Barrel") || collision.gameObject.CompareTag("BlueBarrel"))
        {
            Destroy(collision.gameObject);
        }
    }
}
