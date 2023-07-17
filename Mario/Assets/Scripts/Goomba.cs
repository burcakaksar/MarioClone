using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    Rigidbody2D rb;
    //Animator animGoomba;
    [SerializeField] EnemyMovement enemyMovement;
    private Vector2 velocity;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animGoomba = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
    }
    private void Update()
    {
        EnemyDestroy();
    }
    void EnemyDestroy()
    {
        if (transform.position.y< -2)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Koopa"))
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
}
