using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinPane : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
   
    private void Start()
    {
       
        scoreText.text = ScoreManager.instance.scoreText.text;
        highScoreText.text = "HIGHSCORE : " + PlayerPrefs.GetInt("High Score");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevelButton()
    {
        SceneManager.LoadScene(1);
       

    }





}
