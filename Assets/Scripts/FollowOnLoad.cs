using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using Sirenix.OdinInspector;

public class FollowOnLoad : MonoBehaviour
{
    private Camera m_Camera;
    private MMFollowTarget followTarget;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
        CameraFollowsPlayer();
    }
    [Button]
    private void CameraFollowsPlayer()
    {
        player = GameObject.Find("Player");
        followTarget = m_Camera.GetComponent<MMFollowTarget>();
        followTarget.Target = player.transform;
    }
}
