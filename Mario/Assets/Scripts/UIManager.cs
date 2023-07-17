using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    Canvas canvas;
    public PlayerHealth playerHealth;
    //#region Singleton    
    //// #region bu þekilde kullanýlýr... // Kodlarý gruplamak için kullanýlýr.
    //public static UIManager instance; // "Singleton sahnede tek bir obje için kullanýlýr. Örneðin score tabelasý...."

    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        instance = this;
    //    }

    //}
    //#endregion
    private void Start()
    {
        canvas = GetComponent<Canvas>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
        canvas.enabled = false;

    }
    private void Update()
    {
        scoreText.text = "SCORE: " + PlayerPrefs.GetInt("Score");
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("High Score");
        GameOver();
    }
    private void GameOver()
    {
        if(playerHealth.playerLifeCount == 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            //SoundManager.instance.PlayWithIndex(13);
            StartCoroutine(Die());
            //canvas.enabled = true;
            //SoundManager.instance.PlayWithIndex(9);

            
        }
        
    }
    IEnumerator Die() 
    {
        //Destroy(GameObject.FindGameObjectWithTag("Player"));
        //SoundManager.instance.PlayWithIndex(13);
        yield return new WaitForSeconds(1f);
        canvas.enabled = true;
        GameObject.Find("BackgroundMusic").SetActive(false);
        SoundManager.instance.PlayWithIndex(9);
        


    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playerHealth.playerLifeCount = 3;
        ScoreManager.score = 0;

    }
}
