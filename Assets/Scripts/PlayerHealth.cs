using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public GameObject ItemToDrop { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int PointsToGive { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public MMFeedback Feedback { get; set; }

    public void Damage(int damageTaken)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
