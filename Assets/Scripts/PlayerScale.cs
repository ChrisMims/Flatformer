using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using MoreMountains.Feedbacks;
using QFSW.QC;
public class PlayerScale : MonoBehaviour
{
    [SerializeField] private float scale, scaleIncriment = 0.05f, targetScale, maxSize = 10f, minSize = 0.1f;
    public float Scale { get { return scale; } set { scale = value; } }
    public float TargetScale { get { return targetScale; } set { targetScale = value; } }
    public float ScaleIncriment { get { return scaleIncriment; } }

    private CircleCollider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale.x;
        playerCollider = this.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateScaleChange();
        targetScale = Mathf.Clamp(targetScale, minSize, maxSize);
        targetScale = Mathf.Round(targetScale);
    }
    private void CalculateScaleChange()
    {
        transform.localScale = new Vector3(scale, scale);
        playerCollider.transform.localScale = new Vector3(scale, scale);
        if (scale < (targetScale - 0.2))
        {
            scale += scaleIncriment;
        }
        else if (scale > (targetScale + 0.2))
        {
            scale -= scaleIncriment;
        }
        else
        {
            scale = Mathf.Round(scale);
        }

    }

    [Command]
    public void ChangeScale(float newTargetScale)
    {
        if (newTargetScale < 0)
        {
            newTargetScale = -newTargetScale;
        }
        targetScale = Mathf.Clamp(newTargetScale, minSize, maxSize);
    }

    [Command("PlayerScorePlusOne"), Button]
    public void PlusOne()
    {
        targetScale += 1;
    }

    [Command("PlayerScoreMinusOne"), Button]
    public void MinusOne()
    {
        targetScale -= 1;
    }
}
