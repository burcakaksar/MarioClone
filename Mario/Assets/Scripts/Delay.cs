using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    [SerializeField] float delayTimer=3f; //unity üzerinde istediðimiz zamaný verebilmek için ekledik

    public bool delayTime = true;

    #region Singleton
    public static Delay instance;//singleton

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    public void StartDelayTime()
    {
        StartCoroutine(DelayNewTime()); //bu fonksiyonun kendisini direk çaðiramadýðýmýz için IEnumeratorden dolayý, yeni bir fonksiyon oluþturup öyle çaðýrýyoruz
    }

    IEnumerator DelayNewTime()
    {
        if (delayTime)
        {
            yield return new WaitForSeconds(delayTimer);
            LevelManager.instance.PlayerRespawn();            
        }
        
    }
}
