using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using QFSW.QC;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int Health { get; set; }
    [field: SerializeField] public int MaxHealth { get; set; }

    // Player does not drop items
    public GameObject ItemToDrop { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    // Player does not drop points
    public int PointsToGive { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public MMFeedbacks DamagedFeedback { get; set; }
    // For the player, this will be the death animation feedback
    public MMFeedbacks DestroyedFeedback { get; set; }

    public MMProgressBar healthBar;

    public CalculateDamage calculateDamage;

    [Button("Inititialize")]
    private void Start()
    {
        calculateDamage = GetComponent<CalculateDamage>();
        MaxHealth = 100;
        Health = MaxHealth;
    }

    [Button]
    public void TakeDamage(int damageTaken)
    {
        //calculateDamage.TakeDamage(Health, damageTaken);
        var adjustedHealth = calculateDamage.RawDamage(Health, damageTaken);
        if (adjustedHealth < 0)
        {
            // Die and stuff
            Destroy();
        }
        else if (adjustedHealth >= 0)
        {
            // Take damage

        }
    }

    public void SetHealth(int newValue)
    {
        Health = newValue;

        healthBar.UpdateBar(Health, 0, MaxHealth);
    }
    public void SetMaxHealth(int newValue)
    {
        MaxHealth = newValue;

        healthBar.UpdateBar(Health, 0, MaxHealth);
    }

    [Button]
    public void ReadHealth()
    {
        Debug.Log("Health: " + Health);
    }

    [Button, Command]
    public void Destroy()
    {
        // Kill player; game over
        Debug.Log("Game Over");
        
    }
}
