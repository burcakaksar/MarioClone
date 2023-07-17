using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public float xMin;
    public float xMax;

    void Start()
    {

    }
    private void Update()
    {
        if ((player =GameObject.FindGameObjectWithTag("Player")) != null)
        {

            CamFollow();
        }

       
        
    }

    private void CamFollow()
    {
        float x = Mathf.Clamp(transform.position.x, player.transform.position.x+xMin, player.transform.position.x+xMax);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}

