using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] public static SpriteRenderer miniMario;
    [SerializeField] public static SpriteRenderer bigMario;
    [SerializeField] public Animator animSmall;
    [SerializeField] public Animator animBig;
    bool died = false;

    public static BoxCollider2D newcollider2D;
    PlayerHealth playerHealth;

    public float bounce;
    public float MoveSpeed = 8f;
    public float horizontalMove;
    EnemyMovement enemyMovement;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        miniMario = GameObject.Find("MiniMario").GetComponent<SpriteRenderer>();
        bigMario = GameObject.Find("BigMario").GetComponent<SpriteRenderer>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
        newcollider2D = GetComponent<BoxCollider2D>();
        enemyMovement = GetComponentInParent<EnemyMovement>();


    }

    void Start()
    {
        newcollider2D.enabled = false;
        died = false;

    }

    void Update()
    {
        HorizontalMovement();
        Flip();
        PlayerDestroy();

    }

    void HorizontalMovement()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMove * 8, rb.velocity.y);
        animSmall.SetFloat("Move", Mathf.Abs(horizontalMove));
        animBig.SetFloat("Move", Mathf.Abs(horizontalMove));

    }

    public void Flip()
    {
        if (horizontalMove > 0)
        {
            miniMario.flipX = false;
            bigMario.flipX = false;

        }
        else if (horizontalMove < 0)
        {
            miniMario.flipX = true;
            bigMario.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.CompareTag("Goomba") || collision.collider.gameObject.CompareTag("Koopa") && !died)
        {
            if (miniMario.enabled == true)
            {
                animSmall.SetTrigger("Death");
                died = true;
                rb.gravityScale = 0;
                CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
                transform.DOMoveY(transform.position.y + 1, 0.25f);
                collider.enabled = false;
                Debug.Log(collision.gameObject.name);


                Destroy(gameObject,.5f);

                playerHealth.Lives();
                if (Delay.instance.delayTime == true)
                {
                    Delay.instance.StartDelayTime();
                }
            }
            else if (bigMario.enabled == true)
            {
                bigMario.enabled = false;
                died = true;
                newcollider2D.enabled= false;
                miniMario.enabled = true;
                SoundManager.instance.PlayWithIndex(16);
            }
        }
        if (collision.collider.CompareTag("TopCol"))
        {
            rb.velocity = new Vector2(rb.velocity.x, bounce);

        }
    }

    void PlayerDestroy()
    {
        if (transform.position.y < -17)
        {
            playerHealth.Lives();
            if (Delay.instance.delayTime == true)
            {
                Delay.instance.StartDelayTime();
            }
            Destroy(gameObject);
        }
    }

}
