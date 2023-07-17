using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverScript : MonoBehaviour
{
    GameObject gameLost;
    private void Awake()
    {
        gameLost = GameObject.FindWithTag("GameOver");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Destroy(PlayerHealth.instance.gameObject);
        Destroy(ScoreManager.instance.gameObject);
        Destroy(UIManagerScript.instance.gameObject);
        
    }

    public void Exit()
    {
        Application.Quit();

    }
    public void Restart()
    {
        Destroy(PlayerHealth.instance.gameObject);
        Destroy(ScoreManager.instance.gameObject);
        Destroy(UIManagerScript.instance.gameObject);
        SceneManager.LoadScene(1);

       

    }


}
