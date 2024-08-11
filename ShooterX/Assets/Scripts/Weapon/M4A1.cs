using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A1 : Weapon
{
    private void Awake()
    {
        name = "M4A1";
        damage = 20;
        ammoCapacity = 30;
        spareAmmoCapacity = 240;
        currentAmmo = ammoCapacity;
        range = 1000f;
        fireRate = 0.07f;
        bulletSpeed = 80f;
        reloadTime = 2.5f;
        accuracy = 90f;
    }


    protected override GameObject GetPooledBullet()
    {
        return ObjectPool.SharedInstance.GetPooledM4A1Bullet();
    }
}
