using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockItems : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 velocity;
    

    bool itemMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        velocity = Vector2.right;
        ItemMove();
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void ItemMove()
    { Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveY(transform.position.y + 1f, .5f, snapping: false));
        sequence.OnComplete(() => itemMove = true);
        SoundManager.instance.PlayWithIndex(20);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            if (rb.velocity.x == 0 && velocity == Vector2.left)
            {
                velocity = Vector2.right;
            }
            else
            {
                velocity = Vector2.left;
            }
            Debug.Log("çalýþtý");
        }

        if (collision.gameObject.CompareTag("Player"))// big mario plduðu  yer mantarý yiyince
        {
            PlayerMovement.miniMario.enabled = false;
            PlayerMovement.bigMario.enabled = true;
            PlayerMovement.newcollider2D.enabled = true;
            SoundManager.instance.PlayWithIndex(16);
            Destroy(gameObject); //çýkan musroomlara deðince yok olmalý musroomlar
        }
    }

    private void Move()
    {
        if (itemMove)
            rb.velocity = velocity * 2f;
    }
}
