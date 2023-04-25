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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(float score)
    {
        playerScore = score;
    }
}
