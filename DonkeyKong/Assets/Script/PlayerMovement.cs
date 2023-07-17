using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private PlayerHealth playerHealth;
    [SerializeField] float moveSpeed;
    [SerializeField] float climpSpeed;
    [SerializeField] float jumpPower;
    public float hammerTime = 5;
    public bool hammerOn;
    private bool canJump = true;
    [SerializeField] Transform feetPos;
    [SerializeField] float radius;
    [SerializeField] LayerMask layerMask;
    public float moveX, moveY;
    private Animator anim;


    #region Singleton
    public static PlayerMovement instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion


    void Start()
    {
        LevelManagerMemo.instance.canMove = true;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        playerHealth = GameObject.Find("PlayerHealt").GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();


    }


    void Update()
    {
        stopIt2();
        MovementAction();
        Jump();

    }
    private void FixedUpdate()
    {

        if (LevelManagerMemo.instance.canClimp && !LevelManagerMemo.instance.died)
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(moveX, moveY);
        }
        else
        {
            rb.isKinematic = false;
            rb.velocity = new Vector2(moveX, rb.velocity.y);
        }
    }

    void MovementAction()
    {
        if (LevelManagerMemo.instance.canMove && !LevelManagerMemo.instance.died)
        {
            moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
            anim.SetFloat("isRuns", Mathf.Abs(moveX));
            SpriteFlip(moveX);
            //SoundManager.instance.PlayWithIndex(8);
        }
        if (LevelManagerMemo.instance.canClimp && !LevelManagerMemo.instance.died)
        {
            moveY = Input.GetAxisRaw("Vertical") * climpSpeed;
        }

    }
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded() && !LevelManagerMemo.instance.died && canJump)
        {
            anim.SetBool("Jump", true);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            SoundManager.instance.PlayWithIndex(7);
        }
        if (rb.velocity.y < -1 && IsGrounded() && anim.GetBool("Jump"))
        {
            anim.SetBool("Jump", false);
        }

    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);

    }

    void SpriteFlip(float horizontalMove)
    {
        if (horizontalMove > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalMove < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
    }
    public void StopIt()
    {
        moveX = 0;
        LevelManagerMemo.instance.died = true;
        SoundManager.instance.PlayWithIndex(1);

    }

    public void die()
    {
        playerHealth.Lives();
        hammerTime = 5;
        Destroy(gameObject);

    }

    public void stopIt2()
    {
        if (hammerOn && !LevelManagerMemo.instance.died)
        {
            if (hammerTime > 0)
            {
                LevelManagerMemo.instance.canClimp = false;
                canJump = false;
                hammerTime -= Time.deltaTime;

            }
            else
            {
                canJump = true;
                anim.Play("idle");
                hammerOn = false;
                hammerTime = 5;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetPos.position, radius);

    }

}
