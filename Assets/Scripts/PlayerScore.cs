using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using QFSW.QC;
using MoreMountains.Feedbacks;

public class PlayerScore : MonoBehaviour
{
    private float score;
    public float Score
    {
        get
        {
            return score;
        }
        private set
        {
            score = value;
        }
    }
    private void Start()
    {
        Score = 0;
    }
    [Button]
    public void UpdateScore(float valueToAdd)
    {
        score += valueToAdd;
        Debug.Log(score);
    }
}
