using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountScript : MonoBehaviour
{


    public int countForWin;
    public int level = 1;

    #region
    public static CountScript instance;
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
    public bool EndCount()
    {
        if (countForWin == LevelManagerMemo.instance.count)
        {
            return true;
        }

        return false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
