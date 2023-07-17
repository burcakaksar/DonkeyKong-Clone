using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    Canvas canvas;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI endGameScoreText;

    public int level = 0;
    public int score;
    public static int highScore;
    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    #region Singleton
    public static ScoreManager instance;
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
   
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex!=1)
        {
            level = SceneManager.GetActiveScene().buildIndex;

        }
        Score();
        highScore = PlayerPrefs.GetInt("High Score");
        endGameScoreText.text= "Score : " + score.ToString();
        highScoreText.text = "High Score " + highScore.ToString();
       
    }
    
    public void Score()
    {
        scoreText.text = "Score : " + score.ToString();
        if (highScore < score)
        {
            PlayerPrefs.SetInt("High Score", score);

        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        canvas.enabled = false;
        ScoreManager.instance.score = 0;
        
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
        ScoreManager.instance.score = 0;
    }

}
