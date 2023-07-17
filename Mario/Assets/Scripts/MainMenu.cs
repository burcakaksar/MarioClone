using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public TextMeshProUGUI highScoreText;
    private void Start()
    {
        Time.timeScale = 0;
       
    }
    private void Update()
    {
        //PlayerGame();
        ScoreManager.highScore = PlayerPrefs.GetInt("High Score: ");
        highScoreText.text = "HIGH SCORE:  " + ScoreManager.highScore;
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void PlayerGame()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
