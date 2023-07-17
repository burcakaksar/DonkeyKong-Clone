using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
    [SerializeField] Canvas wins;
    private void Update()
    {
        wins = GameObject.FindGameObjectWithTag("WinPanel").GetComponent<Canvas>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wins.enabled = true;
        }
    }
}
