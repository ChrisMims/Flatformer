using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using QFSW.QC;

public class DevCheats : MonoBehaviour
{
    public GameObject playerGo;
    public Player player;
    [Header("Scale"), SerializeField]
    private PlayerScale playerScale;
    private PlayerScore playerScore;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerScale = playerGo.GetComponent<PlayerScale>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button("+1")]
    private void PlayerScalePlusOne()
    {
        player.Scale += 1;
    }

    [Button("-1")]
    private void PlayerScaleMinusOne()
    {
        player.Scale -= 1;
    }
}
