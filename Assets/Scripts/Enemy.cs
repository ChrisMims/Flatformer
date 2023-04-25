using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int Health { get; set; }
    public int MaxHealth { get; set; }
    public GameObject ItemToDrop { get; set; }
    public int PointsToGive { get; set; }
    public MMFeedbacks DamagedFeedback { get; set; }
    public MMFeedbacks DestroyedFeedback { get; set; }

    [Header("Attack")]
    [SerializeField] protected float _attackRange = 3f;

    public virtual void AttackPlayer()
    {
        Debug.Log("PLAYER WAS HIT OH NO");
        Debug.Log(Health);
    }
    public void Destroy()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damageTaken)
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGEREDEDED BY " + collision);
        Debug.Log("Enemey health: " + Health);
        
    }
}
