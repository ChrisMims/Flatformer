using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using QFSW.QC;
using MoreMountains.Feedbacks;

public interface IDamageable
{
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public GameObject ItemToDrop { get; set; }
    public int PointsToGive { get; set; }
    public MMFeedbacks DamagedFeedback { get; set; }
    public MMFeedbacks DestroyedFeedback { get; set; }
    void TakeDamage(int damageTaken);
    /// <summary>
    /// Award points, drop items, call feedbacks, and clean up game objects
    /// </summary>
    void Destroy();
}
