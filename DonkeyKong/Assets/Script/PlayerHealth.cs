using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    UIManagerScript uiManager;
    [SerializeField] Image[] playerHealthIcons;
    [SerializeField] int playerLifeCount = 2;
    [SerializeField] GameObject gameOver;
    #region Singleton
    public static PlayerHealth instance;
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
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    private void Start()
    {
        uiManager = GetComponent<UIManagerScript>();
    }
    public void Lives()
    {
        playerLifeCount--;
        Destroy(playerHealthIcons[playerLifeCount]);
        

        if (playerLifeCount > 0)
        {
            SceneManager.LoadScene(1);
            LevelManagerMemo.instance.PlayerSpawner();           

        }

        else if (playerLifeCount < 1)
        {
            gameOver.SetActive(true);
            LevelManagerMemo.instance.died = true;
        }



    }

}
