using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PlayerSpawner : MonoBehaviour
{
    private Player player;
    private Transform spawnPoint;
    public MMFeedback spawnFeedback;
    private PlayerScore playerScore;
    private PlayerScale playerScale;
    private PlayerHealth playerHealth;
    private GameObject gameManager, playerGo;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        playerGo = GameObject.Find("Player");
        playerHealth = playerGo.GetComponent<PlayerHealth>();
        playerScore = gameManager.GetComponent<PlayerScore>();
        player = gameManager.GetComponent<Player>();
        playerScale = playerGo.GetComponent <PlayerScale>();

        //playerScale.Scale = 2;
        //playerHealth.Health =
    }
    private void SpawnPlayer()
    {
        playerGo.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
