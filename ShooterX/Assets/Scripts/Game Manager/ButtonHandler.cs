using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Camera thirdPersonCam;
    [SerializeField] private Camera firstPersonCam;
    [SerializeField] private M4A1 gun;
    [SerializeField] private PlayerController player;

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
    public void Jump()
    {
        player.Jump();
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

    public void Run()
    {
        if (!player.isRunning)
            player.Run();
        else
           player.StopRunning();

    }

    public void Crouch()
    {
        if (!player.isCrouching)
            player.Crouch();
        else
            player.GetUp();
    }
}
