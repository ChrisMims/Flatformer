using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using QFSW.QC;

public class Box : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int Health { get; set; }
    [field: SerializeField] public int MaxHealth { get; set; }
    [field: SerializeField] public GameObject ItemToDrop { get; set; }
    [field: SerializeField] public int PointsToGive { get; set; }
    [field: SerializeField] public MMFeedbacks DamagedFeedback { get; set; }
    public MMFeedbacks DestroyedFeedback { get; set; }

    public MMProgressBar PlayerProgressBar;
    public float tempHealth = 100;
    private void Start()
    {
        PlayerProgressBar = GameObject.Find("HUD").GetComponentInChildren<MMProgressBar>();
    }
    [Command("Damage"), Button("Damage")]
    public void TakeDamage(int damageTaken)
    {
        Health -= damageTaken;
        // Break and stuff
        //ProgressBar.UpdateBar(Health, 0, MaxHealth);
    }
    public void DamagePlayer(int damageTaken)
    {
        Health -= damageTaken;
        // Break and stuff
        PlayerProgressBar.UpdateBar(Health, 0, MaxHealth);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionName = collision.gameObject.name;
        if(collision.gameObject.TryGetComponent(out IDamageable damageableObject) && 
            collisionName != "Player")
        {
            Debug.Log("DamageableObject: " + damageableObject.ToString() + "\n Collision: " + collisionName);
        }
    }

    public void Destroy()
    {
        throw new System.NotImplementedException();
    }
}
