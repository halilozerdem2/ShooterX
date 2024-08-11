using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A1 : Weapon
{
    public M4A1()
    {
        name = "M4A1";
        damage = 20;
        ammoCapacity = 20;
        currentAmmo = ammoCapacity;
        range = 1000f;
        fireRate = 0.1f;
        bulletSpeed = 50f;
        reloadTime = 2.5f;
        accuracy = 90f;

    }

    //public override void Reload()
    //{
    //    throw new System.NotImplementedException();
    //}

    protected override GameObject GetPooledBullet()
    {
        return ObjectPool.SharedInstance.GetPooledM4A1Bullet();
    }
}
