using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.ParticleSystem;

public class BlockHit : MonoBehaviour
{
    [SerializeField]public Sprite emptyBlock;
    [SerializeField ]public int maxHits;
    SpriteRenderer spriteRendrer;
    [SerializeField] public GameObject item;
    [SerializeField] ParticleSystem partical1;
    [SerializeField] ParticleSystem partical2;



    private void Start()
    {
        spriteRendrer = GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Hit();
            SoundManager.instance.PlayWithIndex(12);
        }
    }
    private void Hit()
    {
        spriteRendrer.enabled = true;
        maxHits--;
        if (gameObject.CompareTag("MBlock"))
        {
            if (maxHits == 0)
            {
                spriteRendrer.sprite = emptyBlock;

            }
            if (item != null)
            {
                Instantiate(item, transform.position, Quaternion.identity);
                if (maxHits == 0)
                {
                    item = null;
                }
                DestroyImmediate(item, true);
            }
            if (maxHits >= 0)
            {
                HitAnim();

            }
            
        }
        else if(gameObject.CompareTag("BBlock"))
        {
            if (PlayerMovement.miniMario.enabled == true)// mini marioda  sadece animasyon çalýþmasý için
            {
                HitAnim();
            }
            if (PlayerMovement.bigMario.enabled == true) // Big mario olunca partical system çalýþmasý için
            {
                Instantiate(partical1, gameObject.transform.position, Quaternion.identity);
                Instantiate(partical2, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
                if (maxHits == 0)
                {
                    item = null;
                }
            }
            Destroy(item);
        }
    }

    private void HitAnim()
    {
        Debug.Log("Hit");
        transform.DOLocalMoveY((transform.position.y+.25f), .1f, snapping: false).SetLoops(2,LoopType.Yoyo);
    }

}
