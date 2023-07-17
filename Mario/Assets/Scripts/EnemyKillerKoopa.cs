using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyKillerKoopa : MonoBehaviour
{
    [SerializeField] public Animator animKoopa;
   
    public float shellSpeed = 12f;
    private bool shellPush;
    public static bool isShell;
    Vector2 velocity;
    Rigidbody2D rb;

    private void Start()
    {
        animKoopa = GetComponentInParent<Animator>();
       
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isShell)
        {
            rb.velocity = velocity * shellSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animKoopa.SetTrigger("Shell");
       
            rb.velocity = Vector2.zero;
            if (isShell) {
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRb.velocity.x > 0)
                {
                    velocity = Vector2.right;
                }
                else
                {
                    velocity = Vector2.left;
                }
            }
            isShell = true;
            if (isShell == true)
            {
                Destroy(collision.gameObject);

            }





            //Shell hareket etmeli
            
            ScoreManager.instance.AddScore(100);
            SoundManager.instance.PlayWithIndex(4);

           
        }
        
    }
    
    private void OnBecameInvisible()
    {
        if(shellPush)
        {
            Destroy(gameObject);
        }
    }
}
