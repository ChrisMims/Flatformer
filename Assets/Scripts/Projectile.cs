using MoreMountains.Feedbacks;
using UnityEngine;

public abstract class Projectile : MonoBehaviour, IProjectile
{
    [field: SerializeField] public int DamageToInflict { get; set; }
    [field: SerializeField] public MMFeedbacks HitFeedback { get; set; }
    [field: SerializeField] public float Speed { get; set; }
    [field: SerializeField] public GameObject ProjectilePrefab { get; set; }

    public virtual void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // Look for IDamageable
        var collisionName = collision.gameObject.name;

        if (DamageToInflict == 0) { DamageToInflict = 1; }

        if (collision.gameObject.TryGetComponent(out IDamageable damageableObject) &&
            collisionName != "Player")
        {
            // Damage object
            damageableObject.TakeDamage(DamageToInflict);

        }
        else if (collisionName == "Player")
        {
            Debug.Log("Player hit!");
        }
        else
        {
            Debug.LogWarning(gameObject.name + " collided with " + collisionName);
        }

        HitFeedback?.PlayFeedbacks();

        GameObject.Destroy(this.gameObject);
    }
}
