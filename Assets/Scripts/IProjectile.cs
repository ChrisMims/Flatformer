using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using Sirenix.OdinInspector;
using QFSW.QC;

public interface IProjectile
{
    public int DamageToInflict { get; set; }
    public MMFeedbacks HitFeedback { get; set; }
    public float Speed { get; set; }

    void Update();
}
