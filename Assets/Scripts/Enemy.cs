using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public virtual void Start()
    {
        HealthBar = GetComponent<MMHealthBar>();
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
        }
        else
        {
            DestroyedFeedback?.PlayFeedbacks();
            Destroy();
        }

        //HealthBar.UpdateBar(Health, 0, MaxHealth, true);
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

        GameObject.Destroy(this.gameObject);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO:
        // force is how forcefully we will push the player away from the enemy.
        float force = 3;

        // If the object we hit is the enemy
        if (collision.gameObject.tag == "enemy")
        {
            // We then get the opposite (-Vector3) and normalize it
            //dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            //GetComponent<Rigidbody2D>().AddForce(dir * force);
        }
    }
}
