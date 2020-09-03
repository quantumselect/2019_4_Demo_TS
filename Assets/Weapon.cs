using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    BulletPool bPool;
    public Transform fpCamera;
    public Transform firePoint;

    //Gun Setting
    public float firePower = 10;

    //State
    public bool isShooting;
    public float fireSpeed;
    public float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        bPool = BulletPool.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            if (fireTimer > 0) fireTimer -= Time.deltaTime;
            else
            {
                fireTimer = fireSpeed;
                Shoot();
            }

        }
        
    }
    public void Shoot()
    {
        //Calculate Bullet Velocity
        Vector3 bulletVelocity = fpCamera.forward * firePower;

        //pick (spawn) bullet
        bPool.PickFromPool(firePoint.position, bulletVelocity);

    }

    public void PullTrigger()
    {
        if (fireSpeed > 0) isShooting = true;
        else Shoot();
                

    }

    public void ReleaseTrigger()
    {
        //stop shooting
        isShooting = false;

        //set countdown timer to zer
        fireTimer = 0;
    }
}
