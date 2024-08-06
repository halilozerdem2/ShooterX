using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint, crosshair;
    public Vector3 targetPosition;
    public GameObject bulletPrefab;
    public Camera fpCamera, tpCamera;

    public float bulletSpeed = 10f;


    private void Update()
    {
        CreateTargetSpot();
    }
    private Vector3 CreateTargetSpot()
    {
        Ray ray = ChooseActiveCamera().ScreenPointToRay(crosshair.transform.position);
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.yellow);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit.point);
            targetPosition = hit.point;
        }
        else
            targetPosition = Vector3.forward;
        return targetPosition;
    }

    private Camera ChooseActiveCamera()
    {
        Camera activeCamera;
        if (fpCamera.isActiveAndEnabled)
            activeCamera = fpCamera;
        else
            activeCamera = tpCamera;
        return activeCamera;
    }

    public void Shoot()
    {
        GameObject tmpBullet = ObjectPool.SharedInstance.GetPooledObject();
        if (tmpBullet != null)
        {
            tmpBullet.transform.position = bulletSpawnPoint.position;
            tmpBullet.transform.rotation = bulletSpawnPoint.rotation;
            tmpBullet.SetActive(true);
            Rigidbody tmpRb = tmpBullet.GetComponent<Rigidbody>();

            // Calculate the direction from the bullet spawn point to the target position
            Vector3 direction = (targetPosition - bulletSpawnPoint.position).normalized;

            // Set the bullet's velocity towards the target position
            tmpRb.velocity = direction * bulletSpeed;

        }
    }
}
