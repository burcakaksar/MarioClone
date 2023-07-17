using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowerCam : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam;
    [SerializeField] Transform playerPosition;
    [SerializeField] GameObject player;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            playerPosition = player.transform;
        }
        else
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
        }
        vcam.Follow = playerPosition;

    }
}
