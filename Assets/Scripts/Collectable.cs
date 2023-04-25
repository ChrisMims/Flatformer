using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour, IDamageable
{
    public int Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int MaxHealth { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public GameObject ItemToDrop { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int PointsToGive { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public MMFeedback DamagedFeedback { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public abstract void TakeDamage(int damageTaken);
}
