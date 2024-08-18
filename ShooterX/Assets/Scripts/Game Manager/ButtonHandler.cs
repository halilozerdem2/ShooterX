using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Camera thirdPersonCam;
    [SerializeField] private Camera firstPersonCam;
    [SerializeField] private M4A1 gun;
    [SerializeField] private MovingStateManager player;

    private bool isShooting = false;

    public void SwitchCamera()
    {
        firstPersonCam.gameObject.SetActive(!firstPersonCam.gameObject.activeSelf);
        thirdPersonCam.gameObject.SetActive(!thirdPersonCam.gameObject.activeSelf);
    }

    public void StartShooting()
    {
        if (!isShooting && gun != null)
        {
            isShooting = true;
            StartCoroutine(ShootContinuously());
        }
    }

    private IEnumerator ShootContinuously()
    {
        while (isShooting)
        {
            gun.Shoot();
            yield return new WaitForSeconds(gun.fireRate);
        }
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    public void Crouch()
    {
        player.isCrouching = !player.isCrouching;
    }
    public void Run()
    {
        player.isRunning=!player.isRunning;
    }
    public void Jump()
    {

    }

}
