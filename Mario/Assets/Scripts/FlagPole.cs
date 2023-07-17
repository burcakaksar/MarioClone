using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class FlagPole : MonoBehaviour
{
    int time = 0;
    int startScore;
    int endScore = 1000;
    int testScore;

    public float transitionDuration = 10000f; // Geçiþ süresi
    public float startValue = 0f; // Baþlangýç deðeri
    public float endValue = 100f; // Hedef deðer
    float lerpedValue;
    private float lerpedTime;
    private float elapsedTime = 0f; // Geçen süre
    public Transform flag;
    public Transform poleBottom;
    public Transform poleEnd;
 

    public Transform castle;
    public float speed = 6f;
  

    private void Start()
    {
       
    }
    private void Update()
    {
        startScore = PlayerPrefs.GetInt("Score");
        //   Debug.Log(endScore);
        //    Debug.Log(testScore);

        //    elapsedTime += Time.deltaTime; // Geçen süreyi güncelle

        //    // Lerp fonksiyonuyla deðeri yavaþça arttýr

        //    // Deðeri kullan veya uygula
        //    // Örneðin:

        //    // Geçiþ tamamlandýðýnda sýfýrla veya durdur
        //    if (elapsedTime >= transitionDuration)
        //    {
        //        // Geçiþi tamamla veya durdur
        //        elapsedTime = 0f;
        //        // Ýstediðiniz bir þey yapabilirsiniz
        //    }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager.instance.isGameFinish = true;

        endScore = startScore + 100 * (int)ScoreManager.instance.time;
        StartCoroutine(LerpValue(ScoreManager.score, endScore, ScoreManager.instance.time, 0));
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform player = collision.gameObject.GetComponent<Transform>();
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            flag.DOMoveY(poleBottom.position.y, 1f);
            SoundManager.instance.PlayWithIndex(8);
            playerRb.velocity = Vector2.zero;
            LevelEnd(player);
            
            
        }


        //StartCoroutine(MoveTo(flag, poleBottom.position));
        //StartCoroutine(LevelComplete(collision.transform));



    }

    IEnumerator LerpValue(float startValue, float endValue, float time, float endTime)// zaman eksilirken puan artmasý için yaptýðýmýz time mekaniði
    {
        float timeElapsed = 0;
        while (elapsedTime < transitionDuration)
        {
            float t = timeElapsed / transitionDuration;// geçiþ zamaný / bütün zaman olarak aldýk
            lerpedValue = Mathf.Lerp(startValue, endValue, t);// baþlangýç deðerini bitiþ deðerini geçiþ süresü zamanýnda verir
            lerpedTime = Mathf.Lerp(time, endTime, t);
            timeElapsed += Time.deltaTime;// geçen zamaný gerçek zamana atar
            Debug.Log(lerpedValue);
            ScoreManager.instance.scoreText.text = "SCORE : " + lerpedValue.ToString("F0");
            ScoreManager.instance.timerText.text = "TIME : " + lerpedTime.ToString("F0");
            if (PlayerPrefs.GetInt("High Score")<lerpedValue)
            {
                PlayerPrefs.SetInt("High Score", (int)lerpedValue);
            }

            yield return null;
        }
        lerpedValue = endValue;

    }
    void LevelEnd(Transform player)
    {
        Sequence mySqeu = DOTween.Sequence();

        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerBoundry>().enabled = false;

        mySqeu.Append(player.DOMove(poleBottom.position, 0.5f, snapping: false));
        mySqeu.Append(player.DOMove(poleEnd.position, 0.1f, snapping: false));
        mySqeu.Append(player.DOMove(castle.position, 2.5f, snapping: false));
  
        




    }

    //private IEnumerator LevelComplete(Transform player)
    //{
    //    player.GetComponent<PlayerMovement>().enabled = false;
    //    yield return MoveTo(player,poleBottom.position);
    //    yield return MoveTo(player, player.position+Vector3.right);
    //    yield return MoveTo(player,player.position+Vector3.right+Vector3.down);
    //    yield return MoveTo(player,castle.position);
    //    player.gameObject.SetActive(false);
    //}
    //private IEnumerator MoveTo(Transform subject, Vector3 destination)
    //{
    //    while (Vector3.Distance(subject.position,destination) > 0.125f) 
    //    {
    //        subject.position=Vector3.MoveTowards(subject.position, destination, speed * Time.deltaTime);
    //        yield return null;
    //    }
    //    subject.position = destination; 
    //}

}
