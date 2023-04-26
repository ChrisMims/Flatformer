using MoreMountains.Feedbacks;
using UnityEngine;

public abstract class Projectile : MonoBehaviour, IProjectile
{
    [field: SerializeField] public int DamageToInflict { get; set; }
    [field: SerializeField] public MMFeedbacks HitFeedback { get; set; }

    public void DealDamage(int damageDealt)
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Look for IDamageable
        var collisionName = collision.gameObject.name;

        if (DamageToInflict == 0) { DamageToInflict = 1; }

        //if (collision.gameObject.TryGetComponent(out IDamageable damageableObject) &&
        //    collisionName != "Player")
        if (collision.gameObject.TryGetComponent(out IDamageable damageableObject))
        {
            // Damage object
            damageableObject.TakeDamage(DamageToInflict);
        }
    }
}
