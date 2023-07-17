using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform barrelPos;
    public GameObject barrel;
    private Animator anims;
    private void Start()
    {
        anims = GetComponent<Animator>();
    }
    public void BarrelSpawner()
    {
        if (LevelManagerMemo.barrelMove==true&&!LevelManagerMemo.instance.died)
        {
                Instantiate(barrel, barrelPos.position, Quaternion.identity);
        }
    }
}

   




