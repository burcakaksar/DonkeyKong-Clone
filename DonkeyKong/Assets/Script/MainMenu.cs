using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoretext;

    private void Start()
    {
        highScoretext.text = "High Score : " + PlayerPrefs.GetInt("High Score");
    }

    public void PlayButton()
    {
       SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
   
}
