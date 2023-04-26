using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class RedEnemy : Enemy, IDamageable
{
    [Button]
    public override void Start()
    {
        Debug.Log(Health + " " + MaxHealth);
        base.Start();
    }
}
