using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundExit : MonoBehaviour
{
    [SerializeField] Transform exitPos;
    [SerializeField] GameObject undergroundCam;
    GameObject mainCam;
        
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.transform.position = exitPos.transform.position;
            SoundManager.instance.PlayWithIndex(15);
         
            undergroundCam.SetActive(false);
            mainCam.SetActive(true);
        }

    }

}
