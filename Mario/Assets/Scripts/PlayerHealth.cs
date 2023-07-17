using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerHealth : MonoBehaviour
{
    public TextMeshProUGUI marioLives;
   
    [SerializeField]GameObject uiManager;
    [SerializeField]public int playerLifeCount = 3;
    
   
   
    // Start is called before the first frame update
    void Start()
    {
        marioLives.text = "LIVES: " + playerLifeCount.ToString();
    } 
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Lives()
    {
        playerLifeCount--;
        

        if (playerLifeCount <= 0)
        {
            Delay.instance.delayTime = false;
        }
        if (playerLifeCount == 1)
        {
            SoundManager.instance.PlayWithIndex(21);
        }
        else
        {
            SoundManager.instance.PlayWithIndex(13);
        }
        
        marioLives.text ="LIVES: "+ playerLifeCount.ToString();
    }
    public void AddLife()
    {
        playerLifeCount++;
       
    }
}
