using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public interface ICollectable
{
    public MMFeedbacks Feedbacks { get; }
    public int Quantity { get; }

    void Interact();

}
