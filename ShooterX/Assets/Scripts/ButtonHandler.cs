using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Camera thirdPersonCam;
    [SerializeField] private Camera firstPersonCam;
    [SerializeField] private M4A1 gun;

    private bool isShooting = false;

    public void SwitchCamera()
    {
        firstPersonCam.gameObject.SetActive(!firstPersonCam.gameObject.activeSelf);
        thirdPersonCam.gameObject.SetActive(!thirdPersonCam.gameObject.activeSelf);
    }

    public void StartShooting()
    {
        if (!isShooting && gun != null) // Added null check for gun
        {
            isShooting = true;
            StartCoroutine(ShootContinuously());
        }
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    private IEnumerator ShootContinuously()
    {
        while (isShooting)
        {
            gun.Shoot();
            yield return new WaitForSeconds(gun.fireRate);
        }
    }
}
