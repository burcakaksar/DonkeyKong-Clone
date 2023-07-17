using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlueBarrel : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject blueBarrel;
    public Transform targetPosition;
    public float barrrelSpeed;
    private bool canMove;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Sequence mySequ = DOTween.Sequence();
        mySequ.Append(blueBarrel.transform.DOMoveY(targetPosition.position.y, 3f).SetEase(Ease.Linear)).OnComplete(() => canMove = true);
        anim.SetTrigger("BlueAnimation");
        Debug.Log("Working");
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        if (canMove)
        {
            rb.velocity = Vector2.left * barrrelSpeed;
            anim.SetTrigger("MoveTry");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Oil"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player") && !LevelManagerMemo.instance.died)
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            LevelManagerMemo.instance.canMove = false;
            anim.SetTrigger("Die");
            SoundManager.instance.PlayWithIndex(1);
            Destroy(gameObject);

        }
    }
}
