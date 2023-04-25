using MoreMountains.Feedbacks;
using UnityEngine;

public abstract class Crate : MonoBehaviour, IDamageable
{
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public GameObject ItemToDrop { get; set; }
    public int PointsToGive { get; set; }
    public MMFeedbacks DamagedFeedback { get; set; }
    public MMFeedbacks DestroyedFeedback { get; set; }

    public void Destroy()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damageTaken)
    {
        throw new System.NotImplementedException();
    }
}
