using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDamage : MonoBehaviour
{
    public int MaxHealth { get; set; }
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int currentHealth, int rawDamage)
    {
        if(currentHealth - rawDamage > 0)
        {
            currentHealth -= rawDamage;
            playerHealth.Health = currentHealth;
            Debug.Log("Health (adjusted): " + playerHealth.Health);
        }
        else
        {
            // Die/Destroy

        }

        //if (Health - this.Health > MaxHealth)
        //{
        //    // Ouch
        //    //DamagedFeedback?.PlayFeedbacks();
        //    Debug.Log("Health: " + Health);

        //}
        //else if (Health - newValue < MaxHealth)
        //{
        //    // Die
        //    playerHealth.DestroyedFeedback?.PlayFeedbacks();
        //}
        //Health = newValue;
        //Debug.Log("Health: " + Health);
    }
    public int RawDamage(int currentHealth, int rawDamage)
    {
        int parsedDamage = rawDamage;
        return currentHealth - rawDamage;
    }
    public void SetMaxHealth(int newValue)
    {
        MaxHealth = newValue;
        Debug.Log("MaxHealth: " + MaxHealth);

    }
}
