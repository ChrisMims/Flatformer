using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;

public class Player : MonoBehaviour
{
    private PlayerScale playerScale;
    private PlayerScore playerScore;
    private GameObject gameManager;
    private PlayerHealth playerHealth;

    public MMProgressBar progressBarProgress;

    #region Get / Set
    public float Scale
    {
        get { return playerScale.Scale; }
        set 
        {
            playerScale.ChangeScale(value);
        }
    }
    public float Score { 
        get
        {
            return playerScore.Score;
        }
        set
        {
            playerScore.UpdateScore(value);
        }
    }
    public float Health { 
        get
        {
            return playerHealth.Health;
        }
        set
        {
            // TODO: Impliment
        }
    }
    public float MaxHealth
    {
        get
        {
            return playerHealth.Health;
        }
        set
        {
            // TODO: Impliment
        }
    }
    #endregion

    [Button("Initialize")]
    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        playerScale = gameObject.GetComponent<PlayerScale>();
        if(gameManager != null)
        {
            playerScore = gameManager.GetComponent<PlayerScore>();
        }

        Scale = 2;
        Score = 0;

        Health = 100;
        MaxHealth = 100;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageableObject))
        {
            //collision.gameObject.SetActive(false);
            damageableObject.Damage(2);
        }
    }

    #region Debug Buttons
    [Button("Scale +1")]
    public void Test1()
    {
        if(playerScale != null)
        {
            playerScale.PlusOne();
        }
    }
    [Button("Scale -1")]
    public void Test2()
    {
        if(playerScale != null)
        {
            playerScale.MinusOne();
        }
    }
    #endregion
}
