using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class RedEnemy : Enemy, IDamageable
{
    [Button]
    private void Start()
    {
        Debug.Log(Health + " " + MaxHealth);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("RedEnemy Health: " + Health);
        AttackPlayer();
    }

    [Button]
    public override void AttackPlayer()
    {
        base.AttackPlayer();
    }

    [Button]
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("...");
        base.OnTriggerEnter2D(collision);
    }
}
