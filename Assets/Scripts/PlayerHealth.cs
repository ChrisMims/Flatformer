using MoreMountains.Feedbacks;
using QFSW.QC;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int Health { get; set; }
    public int MaxHealth { get; set; }

    // Player does not drop items
    public GameObject ItemToDrop { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    // Player does not drop points
    public int PointsToGive { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public MMFeedbacks DamagedFeedback { get; set; }
    // For the player, this will be the death animation feedback
    public MMFeedbacks DestroyedFeedback { get; set; }

    public void TakeDamage(int damageTaken)
    {
        if (Health - damageTaken > MaxHealth)
        {
            // Ouch
            DamagedFeedback?.PlayFeedbacks();

        }
        else if (Health - damageTaken < MaxHealth)
        {
            // Die
            DestroyedFeedback?.PlayFeedbacks();
        }
    }

    public void SetHealth(int newValue)
    {
        Health = newValue;
        Debug.Log("Health: " + Health);
    }
    public void SetMaxHealth(int newValue)
    {
        MaxHealth = newValue;
        Debug.Log("MaxHealth: " + MaxHealth);
    }

    [Button, Command]
    public void Destroy()
    {
        // Kill player; game over

        throw new System.NotImplementedException();
    }
}
