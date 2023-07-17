using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeadZoneScript : MonoBehaviour
{
    PlayerHealth playerHealty;
    private void Start()
    {
        playerHealty = GameObject.Find("PlayerHealt").GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            playerHealty.Lives();    
        }
        Destroy(collision.gameObject);   
    }
}
