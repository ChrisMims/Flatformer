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

}
