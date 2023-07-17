using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DonkeyLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DonkeyKongLoadSene", 3);
    }
    private void DonkeyKongLoadSene()
    {
        if (ScoreManager.instance.level==0)
        {
            SceneManager.LoadScene(2);

        }
        else
        {
            
            SceneManager.LoadScene(ScoreManager.instance.level);

        }


    }

}
