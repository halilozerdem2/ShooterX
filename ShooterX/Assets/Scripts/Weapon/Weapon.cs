using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Camera fpCamera, tpCamera;
    public Transform crosshair, BulletSpawnPoint;
    public GameObject BulletType;
    public Vector3 targetPosition;
    public Animator characterAnim;

    public string name { get; set; }

    public int damage { get; set; }
    public int ammoCapacity { get; set; }
    public int spareAmmoCapacity { get; set; }
    public int currentAmmo { get; set; }
    public bool isReloading { get; set; }
    public bool isShooting { get; set; }
    public bool canShoot { get; set; }

    public float bulletSpeed { get; set; }
    public float fireRate { get; set; }
    public float range { get; set; }
    public float reloadTime { get; set; }
    public float accuracy { get; set; }


    private protected virtual Camera SelectActiveCamera()
    {
        if (fpCamera.isActiveAndEnabled)
            return fpCamera;
        else
            return tpCamera;
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
    public virtual void Shoot()
    {
        if (!isReloading)
        {
            GameObject tmpBullet = GetPooledBullet();
            if (tmpBullet != null)
            {
                tmpBullet.transform.position = BulletSpawnPoint.position;
                tmpBullet.transform.rotation = BulletSpawnPoint.rotation;
                tmpBullet.SetActive(true);

                Rigidbody tmpRb = tmpBullet.GetComponent<Rigidbody>();
                Vector3 direction = (targetPosition - BulletSpawnPoint.position).normalized;
                tmpRb.velocity = direction * bulletSpeed;
                currentAmmo--;
            }
        }
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


    protected virtual void Onhit()
    {
        //this.gameObject.SetActive(false);
    }
    private void Update()
    {
        Aim();
    }

}
