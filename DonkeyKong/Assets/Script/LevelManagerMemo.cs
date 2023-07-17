using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerMemo : MonoBehaviour
{

    public bool canWin;
    public static bool barrelMove = true;
    [SerializeField] public int count;

    #region Singleton
    public static LevelManagerMemo instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    #region values
    [Header("Values")]
    public bool canClimp;
    public bool canMove;
    public bool died;

    [Header("Player Spawner")]
    [SerializeField] Transform playerSpawner;
    [SerializeField] GameObject warHammer;
    [SerializeField] GameObject Player;
    #endregion

    public void PlayerSpawner()
    {
        StartCoroutine(PlayerSpawnDelay());

    }
    IEnumerator PlayerSpawnDelay()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(Player, playerSpawner.position, Quaternion.identity);
        warHammer.SetActive(true);
        died = false;
    }
}
