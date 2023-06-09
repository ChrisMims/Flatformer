using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;
using MoreMountains.Feedbacks;
using Sirenix.OdinInspector;

public class Bullet : Projectile, IProjectile
{
    public int DamageToInflict { get; set; }
    public MMFeedbacks HitFeedback { get; set; }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
