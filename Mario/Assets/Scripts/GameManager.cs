using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    
    public int world {get; private set;}
    public int stage { get; private set; }
    public int lives { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance =null;
        }
    }
    private void Start()
    {
        NewGame();
    }
    private void NewGame()
    {

    }
}
