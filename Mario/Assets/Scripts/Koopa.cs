using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Koopa : MonoBehaviour
{
    private Rigidbody2D rb;
    SpriteRenderer koopaSprite;
    public static BoxCollider2D kCollider;
    private Vector2 velocity;
    EnemyMovement enemyMovement;
    public float koopaSpeed = 1f;
 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enabled = false;
       

    }

    private void Start()
    {
        
        koopaSprite = GameObject.Find("Koopa").GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        kCollider = GetComponent<BoxCollider2D>();
      




    }
    
    private void Update()
    {
        EnemyDestroy();
        Flip();
        
    }
    void EnemyDestroy()
    {
        if (transform.position.y < -2)
        {
            Destroy(gameObject);
        }
    }
    public void Flip()
    {
        if (rb.velocity.x > 0)
        {
            koopaSprite.flipX = true;


        }
        else if (rb.velocity.x < 0)
        {
            koopaSprite.flipX = false;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goomba")|| collision.gameObject.CompareTag("Block"))
        {
            if (rb.velocity.x == 0 && velocity == Vector2.left)
            {
                velocity = Vector2.right;
            }
            else
            {
                velocity = Vector2.left;
            }
        }
    }
    private void KoopaMove()
    {

        rb.velocity = velocity * koopaSpeed;



    }
    

}

