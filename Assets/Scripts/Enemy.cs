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

    protected Player player;
    [Button("Initialize")]
    public virtual void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        HealthBar = this.GetComponent<MMHealthBar>();
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        CheckIfPlayer(collision);
    }

    public virtual void CheckIfPlayer(Collision2D collision)
    {
        var collisionName = collision.gameObject.name;
        if (collision.gameObject.TryGetComponent(out IDamageable damageableObject) &&
            collisionName == "Player")
        {
            Debug.Log("Player hit!");
            // Damage player
            AttackPlayer(_attackDamage);
        }
        else if (collisionName != "Player")
        {
            // Do nothing
        }
    }

    public virtual void AttackPlayer(float attackDamage)
    {
        // TODO: 
        player.Health -= (int)attackDamage;
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
        player.Score += PointsToGive;
        Debug.Log("Player Score: " + player.Score);
        // TODO: Figure out what to do with dead enemies. Just destroy them?
        // Add sound
        // Add an animation
        DestroyedFeedback?.PlayFeedbacks();

        GameObject.Destroy(this.gameObject);
    }
}
