using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            anim.SetTrigger("Hammer");
            PlayerMovement.instance.hammerOn = true;
            //SoundManager.instance.PlayWithIndex(2);
            gameObject.SetActive(false);
            
        }
    }
}
