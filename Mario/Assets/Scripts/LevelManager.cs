using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    PlayerHealth playerHealth;
    [SerializeField] Transform playerPrefab, playerSpawnPos;
    
    public static LevelManager levelManager;

    public static bool canMove;

    public int coins;
    public int score;

    #region Singleton
    public static LevelManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        PlayerSpawnCor();
    }
    #endregion

    void Start()
    {
        canMove = true;
        playerHealth = GetComponent<PlayerHealth>();
        
    }

    void Update()
    {

    }
 
    public void PlayerRespawn()
    {
        //ScoreManager.instance.time = 360f;
        var newPlayer = Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
        
    }
    void PlayerSpawn() //oyuna ilk başlarken  doğar....
    {
        var newPlayer = Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
        
    }

    IEnumerator PlayerSpawnWait()
    {
        yield return new WaitForSeconds(0);
        PlayerSpawn();
    }

    void PlayerSpawnCor()
    {
        StartCoroutine(PlayerSpawnWait());
    }

    public void AddCoin() // coin toplama mekaniğini YAZDIĞIMIZ METOD...
    {
        coins++;
        ScoreManager.instance.AddScore(100);
        if (coins == 100)
        {
            playerHealth.AddLife();
            coins = 0;
            
        }
    }

}
