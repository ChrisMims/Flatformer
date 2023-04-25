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
    [field: SerializeField] public int Health { 
        get
        {
            return playerHealth.Health;
        }
        set
        {
            playerHealth.SetHealth(value);
        }
    }
    [field: SerializeField] public int MaxHealth
    {
        get
        {
            return playerHealth.MaxHealth;
        }
        set
        {
            playerHealth.SetMaxHealth(value);
        }
    }
    #endregion

    [Button("Initialize")]
    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        playerScale = gameObject.GetComponent<PlayerScale>();
        playerHealth = gameObject.GetComponent<PlayerHealth>();
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
            damageableObject.TakeDamage(2);
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
    [Button("Health = 50/100")]
    public void Test3()
    {
        Health = 50;
        MaxHealth = 100;
        Debug.Log(Health + "\n" + MaxHealth);
    }
    [Button("Health = 50/50")]
    public void Test4()
    {
        Health = 50;
        MaxHealth = 50;
        Debug.Log(Health + "\n" + MaxHealth);
    }
    [Button("Health = 100/100")]
    public void Test5()
    {
        Health = 100;
        MaxHealth= 100;
        Debug.Log(Health + "\n" + MaxHealth);
    }
    #endregion
}
