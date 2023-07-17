using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreObjects : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("umbrella"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                ScoreManager.instance.score += 100;
                animator.SetTrigger("addPoint");
            }
        }
        else if (gameObject.CompareTag("phone"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                ScoreManager.instance.score += 300;
                animator.SetTrigger("addPoint");
            }
        }
        else if (gameObject.CompareTag("Tea"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                ScoreManager.instance.score += 500;
                animator.SetTrigger("addPoint");
            }
        }
    }
    private void DestroyUmrella()
    {
        Destroy(gameObject);
    }
}
