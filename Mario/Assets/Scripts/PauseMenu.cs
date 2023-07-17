using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject canvasPause;
  
  



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        canvasPause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        LevelManager.canMove = true;
        
    }
    public void Pause()
    {
        canvasPause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        LevelManager.canMove = false;
        SoundManager.instance.PlayWithIndex(14);


    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        
       LevelManager.canMove = true;
    }
  

    
}

