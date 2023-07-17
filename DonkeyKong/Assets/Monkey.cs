using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    private void Start()
    {
        transform.DOMoveX(5, 4).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Animator animator = collision.GetComponent<Animator>();
            animator.SetTrigger("Die");
        }

    }
}
