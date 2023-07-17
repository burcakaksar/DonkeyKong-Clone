using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.instance.score += 200;
        Invoke("PointDestroyer",1);
    }
    private void PointDestroyer()
    {
        Destroy(gameObject);
    }


}
