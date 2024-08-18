using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Camera fpCamera, tpCamera;
    public Transform crosshair, BulletSpawnPoint;
    public GameObject BulletType;
    public Vector3 targetPosition;

    public int currentAmmo;
    public int spareAmmoCapacity;
    public bool isReloading;
    public float fireRate;

    protected string _name { get; set; }
    protected int damage { get; set; }
    protected int ammoCapacity { get; set; }
    protected bool isShooting { get; set; }
    protected bool canShoot { get; set; }

    protected float bulletSpeed { get; set; }
    protected float range { get; set; }
    protected float reloadTime { get; set; }
    protected float accuracy { get; set; }
    

    private protected virtual Camera SelectActiveCamera()
    {
        if (fpCamera.isActiveAndEnabled)
            return fpCamera;
        else
            return tpCamera;
    }

    public virtual void Shoot()
    {
        Aim();
        if (!isReloading)
        {
            GameObject tmpBullet = GetPooledBullet();
            if (tmpBullet != null)
            {
                isShooting = true;
                tmpBullet.transform.position = BulletSpawnPoint.position;
                tmpBullet.transform.rotation = BulletSpawnPoint.rotation;
                tmpBullet.SetActive(true);

                Rigidbody tmpRb = tmpBullet.GetComponent<Rigidbody>();
                Vector3 direction = (targetPosition - BulletSpawnPoint.position).normalized;
                tmpRb.velocity = direction * bulletSpeed;

                currentAmmo--;
            }
        }
        else
            isShooting = false;
    }
    public virtual Vector3 Aim()
    {
        if (currentAmmo <= 0)
            Reload();

        Ray ray = SelectActiveCamera().ScreenPointToRay(crosshair.transform.position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            targetPosition = hit.point;
        }
        else
            targetPosition = ray.GetPoint(range);

        return targetPosition;
    }
    public virtual void Reload()
    {
        if (spareAmmoCapacity != 0 && !isReloading)
        {
            isReloading = true;
            StartCoroutine(Reloading());
        }
    }

    public IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadTime);
        spareAmmoCapacity -= ammoCapacity;
        currentAmmo = ammoCapacity;
        isReloading = false;
    }

    protected virtual GameObject GetPooledBullet()
    {
        return ObjectPool.SharedInstance.GetDefaultBullets();
    }

}
