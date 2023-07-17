using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    Canvas winCanvas;
    private void Start()
    {
        winCanvas = GetComponent<Canvas>();
    }
    public void NextLevel()
    {
       
        //CountScript.instance.countForWin++;
        //CountScript.instance.level++;
        int scorePoint = ScoreManager.instance.score;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        LevelManagerMemo.instance.canMove = true;
        winCanvas.enabled = false;


    }
    public void Quit()
    {
        Application.Quit();
    }
}
