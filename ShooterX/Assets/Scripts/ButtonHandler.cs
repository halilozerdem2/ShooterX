using UnityEngine;
using UnityEngine.EventSystems; // For handling pointer events
using System.Collections;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Camera thirdPersonCam;
    [SerializeField] private Camera firstPersonCam;
    [SerializeField] private Gun gun;
    public float fireRate = 0.1f;  // Time between shots in seconds
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
            yield return new WaitForSeconds(fireRate);
        }
    }
}
