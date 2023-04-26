using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using MoreMountains.Feedbacks;
using QFSW.QC;

public class PlayerGun : MonoBehaviour
{
    public Transform gunEnd;
    public GameObject bulletPrefab;
    public MMFeedbacks fireFeedback;

    private Vector3 gunEndVector3;
    private GameObject liveBullet;

    [Button("Initialize")]
    void Start()
    {
        Debug.Log("Init");
    }

    [Button]
    public void Shoot()
    {
        gunEndVector3 = gunEnd.transform.position;
        liveBullet = Instantiate(bulletPrefab, gunEndVector3, gunEnd.rotation, null);
    }
}
