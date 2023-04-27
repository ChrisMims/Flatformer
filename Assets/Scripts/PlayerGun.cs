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
    public MMFeedbacks fireFeedback, emptyGunFeedback;

    private Vector3 gunEndVector3;
    private GameObject liveBullet;

    [SerializeField] private float _secondsToTravel = 5f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && CanFire())
        {
            Shoot();
        }
        else if(Input.GetButtonDown("Fire1") && !CanFire())
        {
            // Click
            emptyGunFeedback?.PlayFeedbacks();
        }
    }

    [Button, Command]
    public void Shoot()
    {
        gunEndVector3 = gunEnd.transform.position;
        // Instantiate the bullet, then destroy it after [_secondsToTravel] seconds
        // There are many ways to write this, but I believe in this case the one-line
        // solution is best, if slightly less readable.
        Destroy(Instantiate(bulletPrefab, gunEndVector3, gunEnd.rotation, null), _secondsToTravel);
    }

    private bool CanFire()
    {
        // TODO: Extend this and implement it as a mechanic.
        return true;
    }
}
