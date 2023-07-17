using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorScript : MonoBehaviour
{
    [SerializeField] GameObject youWinPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlayWithIndex(18);
        youWinPanel.SetActive(true);
        Destroy(collision.gameObject);
    }
    
}
