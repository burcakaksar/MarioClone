using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{

    [SerializeField] public Animator animGoomba;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] BoxCollider2D box;
    

    private void Start()
    {
        animGoomba = GetComponentInParent<Animator>();
        enemyMovement = GetComponentInParent<EnemyMovement>();



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animGoomba.SetTrigger("Flat");

            SoundManager.instance.PlayWithIndex(4);
            ScoreManager.instance.AddScore(100);
            enemyMovement.enemySpeed = 0;
            gameObject.GetComponent<Collider2D>().enabled = false;

            box.enabled = false;
        }
        if (EnemyKillerKoopa.isShell == true && collision.gameObject.CompareTag("Koopa"))
        {
            Destroy(gameObject);
            SoundManager.instance.PlayWithIndex(4);
            ScoreManager.instance.AddScore(100);
        }
    }
}
