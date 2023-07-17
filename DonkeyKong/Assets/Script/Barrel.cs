using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float barrelSpeed;
    Rigidbody2D rb;
    public bool rightWall;
    public bool leftWall;
    private void Start()
    {
        rightWall = true;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (leftWall)
        {
            rb.velocity = new Vector3(-barrelSpeed, rb.velocity.y, 0);
        }
        if (rightWall)
        {
            rb.velocity = new Vector3(barrelSpeed, rb.velocity.y, 0);
        }
        if (LevelManagerMemo.instance.died == true)
        {
            Destroy(gameObject);
        }
    }
    public void DestroyBarrels()
    {
        Destroy(gameObject);
    }
    public void DontTouch()
    {
        GetComponent<CircleCollider2D>().enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !LevelManagerMemo.instance.died)
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            LevelManagerMemo.instance.canMove = false;
            anim.SetTrigger("Die");
            SoundManager.instance.PlayWithIndex(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float randoms = Random.Range(1, 5);
        if (randoms<=3)
        {
            if (collision.gameObject.CompareTag("leftWall"))
            {
                LeftSide();
            }
            if (collision.gameObject.CompareTag("rightWall"))
            {
                RightSide();

            }
        }
    }
    public void LeftSide()
    {
        leftWall = true;
        rightWall = false;
    }
    public void RightSide()
    {
        rightWall = true;
        leftWall = false;
    }
}
