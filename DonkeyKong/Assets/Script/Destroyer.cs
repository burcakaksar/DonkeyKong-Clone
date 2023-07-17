using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] GameObject point;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.CompareTag("Barrel"))
        {
            Animator anima = collision.gameObject.GetComponent<Animator>();
            anima.SetTrigger("BarrelDestroy");
            Instantiate(point, collision.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Animator anima = collision.gameObject.GetComponent<Animator>();
            anima.SetTrigger("DieEnemy");
            Instantiate(point, collision.transform.position, Quaternion.identity);

        }
    }
}
