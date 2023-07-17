using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPause;
    [SerializeField] GameObject pauseMenu;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                Resume();

            }
            else  
            { 
                Pause();
            }
        }
    }

    public void Resume()
    {
        isPause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        LevelManagerMemo.instance.canMove = true;
    }
    public void Menu()
    {
        Destroy(PlayerHealth.instance.gameObject);
        Destroy(ScoreManager.instance.gameObject);
        Destroy(UIManagerScript.instance.gameObject);
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        ScoreManager.instance.score = 0;
        LevelManagerMemo.instance.canMove = true;
    }
    public void Pause()
    {
        isPause = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        LevelManagerMemo.instance.canMove = false;

    }
}
