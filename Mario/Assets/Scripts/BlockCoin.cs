using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCoin : MonoBehaviour
{
    [SerializeField] public int maxCoin;
    private void Start()
    {
        LevelManager.instance.AddCoin();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CoinThrow();
        }
    }

    void CoinThrow()
    {
        maxCoin--;
        if(gameObject.CompareTag("CoinItem"))
        {
            if (maxCoin >= 0)
            {
                CoinAnim();
            }
        }
    }
    void CoinAnim()
    {
        transform.DOLocalMoveY((transform.position.y + 3f), .5f, snapping: false).SetLoops(2, LoopType.Yoyo);
        Destroy(gameObject, .9f);
        SoundManager.instance.PlayWithIndex(5);
    }
}

