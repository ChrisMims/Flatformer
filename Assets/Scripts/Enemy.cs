using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int Health { get; set; }
    [field: SerializeField] public int MaxHealth { get; set; }
    [field: SerializeField] public GameObject ItemToDrop { get; set; }
    [field: SerializeField] public int PointsToGive { get; set; }
    [field: SerializeField] public MMFeedbacks DamagedFeedback { get; set; }
    [field: SerializeField] public MMFeedbacks DestroyedFeedback { get; set; }
    [field: SerializeField] public MMHealthBar HealthBar { get; set; }

    [Header("Attack")]
    [SerializeField] protected float _attackRange = 3f;
    [SerializeField] protected float _attackDamage = 5f;
    [SerializeField] protected float _attackSpeed = 1f;
    [Button("Initialize")]
    public virtual void Start()
    {
        HealthBar = this.GetComponent<MMHealthBar>();
    }

    public virtual void AttackPlayer()
    {
        // TODO: 
    }

    public void TakeDamage(int damageTaken)
    {
        if(Health - damageTaken > 0)
        {
            Health -= damageTaken;
            DamagedFeedback?.PlayFeedbacks();

            HealthBar.UpdateBar((float)Health, 0, (float)MaxHealth, true);
        }
        else
        {
            // Refactor: I can probably call UpdateBar(0,0,1,true) in a feedback,
            // but it may be easier to manage from this script.
            HealthBar.UpdateBar(0, 0, 1, true);

            Destroy();
        }
    }
    public void Destroy()
    {
        // Award points to the player
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.Score += 10;
        Debug.Log("Player Score: " + player.Score);
        // TODO: Figure out what to do with dead enemies. Just destroy them?
        // Add sound
        // Add an animation
        DestroyedFeedback?.PlayFeedbacks();

        GameObject.Destroy(this.gameObject);
    }
}
