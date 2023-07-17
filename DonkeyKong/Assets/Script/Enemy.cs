using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float speed;
    [SerializeField] float distance;
    public bool moveRight = true;
    [SerializeField] LayerMask layerMask;
    [SerializeField] private int isClimb;
    [SerializeField] private bool isClimbing = false;
    [SerializeField] private bool isDown = false;
    [SerializeField] private bool canGoDown = false;
    public float climbSpeed;
    private bool canMove = true;
    EnemySpawner spawner;


    [SerializeField] float jumpDistance = 5f;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float duration = 1f;
    [SerializeField] bool goingUp = false;

    int jumpCount = -1;

    [SerializeField] float jump = .75f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }


    void Update()
    {
        EnemyMove();
        Climb();
        GoDown();
        isClimb = Random.Range(0, 2);
        RayTest();
        if (LevelManagerMemo.instance.died == true)
        {
            Destroy(gameObject);
        }
    }

    void EnemyMove()
    {
        if (!isClimbing && !isDown)
        {
            if (moveRight)
            {
                rb.velocity = Vector2.right * speed;
            }
            else
            {
                rb.velocity = Vector2.left * speed;
            }


            if (transform.position.x >= 6f)
            {
                moveRight = false;
            }
            else if (transform.position.x <= -5f)
            {
                moveRight = true;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }
    void Climb()
    {
        if (isClimbing)
        {
            rb.velocity = Vector2.up * climbSpeed;
        }

    }
    void GoDown()
    {
        if (isDown)
        {
            rb.velocity = Vector2.down * climbSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("TriggerStart") && isClimb == 1 && !isClimbing && !canGoDown)
        {
            isClimbing = true;
        }
        if (collision.gameObject.CompareTag("TriggerDown") && canGoDown)
        {
            isDown = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerEnd"))
        {
            isClimbing = false;
            canGoDown = true;
        }
        if (collision.gameObject.CompareTag("DownStart") && canGoDown)
        {
            isDown = false;
            canGoDown = false;
        }
    }
    void RayTest()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance, layerMask);

        if (hit.collider != null && !isClimbing && !isDown)
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + jump, transform.position.z);
        }
        Debug.DrawRay(transform.position, Vector2.down, Color.black);


        if (jump >= .5f)
        {
            goingUp = false;
        }
        else if (jump <= 0.15f)
        {
            goingUp = true;
        }

        if (goingUp == false)
        {
            jump -= Time.deltaTime;
        }
        else
        {
            jump += Time.deltaTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !LevelManagerMemo.instance.died )
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            LevelManagerMemo.instance.canMove = false;
            anim.SetTrigger("Die");
            SoundManager.instance.PlayWithIndex(1);            
        }
        
    }
    public void EnemyDied()
    {
        BoxCollider2D Dies = GetComponent<BoxCollider2D>();
        Dies.gameObject.SetActive(false);
    }
}
