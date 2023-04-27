using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using QFSW.QC;
using MoreMountains.Feedbacks;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private float playerScore;
    public float Score { get { return playerScore; } }
    
    public void UpdateScore(float score)
    {
        playerScore = score;
    }
}
