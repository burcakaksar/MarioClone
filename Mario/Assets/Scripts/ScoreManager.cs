using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{


    [SerializeField] Canvas canvas;
    public bool isGameFinish=false;
    [SerializeField] public float numberStretchtime = 360f;
    public float time;
    public static int score = 0;
    public TextMeshProUGUI   coinText ;
    public static int highScore = 0;
    public TextMeshProUGUI scoreText;
    PlayerHealth playerHealth;
    public TextMeshProUGUI timerText;




    // #region bu þekilde kullanýlýr... // Kodlarý gruplamak için kullanýlýr.

    #region Singleton 
    public static ScoreManager instance; // "Singleton sahnede tek bir obje için kullanýlýr. Örneðin score tabelasý...."
     
                           // bu şekilde kullanılır...  Kodları gruplamak için kullanılır.
                // "Singleton sahnede tek bir obje için kullanılır. Örneğin score tabelası...."


    private void Awake()
    {
         if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        

    }
    #endregion

    void Start()
    {
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
        scoreText.text = "SCORE: " + score.ToString();
        time = numberStretchtime;
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameFinish) 
        {
            Timer(); 
        }
       
        
        CoinsCounter();
    }
    //public void AddCoin()
    //{
    //    coins++;
    //    if (coins == 100)
    //    {
    //        coins = 0;
    //        playerHealth.AddLife();
    //    }
    //}
    public void AddScore(int pointValue)// SCORE MEKANİĞİNİ YAZDIRDIĞIMIZ METOD
    {
        score += pointValue;
        PlayerPrefs.SetInt("Score", score);
        if(PlayerPrefs.GetInt("High Score") < score)
        {
            PlayerPrefs.SetInt("High Score", score);

        }
    }
    
    void Timer()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
            int seconds = Mathf.CeilToInt(time);
            timerText.text = "TIME: " + seconds.ToString();
        }
        else
        {
            timerText.text = "TIME FINISH";
            Die();
            //Restart() ;

        }
    }
    void Die()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Destroy(Player);

        canvas.enabled = true;

    }
    //private void Restart()
    //{
    //    if (playerHealth.playerLifeCount<=0)
    //    {
    //        playerHealth.playerLifeCount = 3;
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //    }
       

       
       
    //}

    public void CoinsCounter()
    {
        coinText.text = "COINS : " + LevelManager.instance.coins.ToString();
        scoreText.text = "SCORE : " + score;
    }

    
    
}


