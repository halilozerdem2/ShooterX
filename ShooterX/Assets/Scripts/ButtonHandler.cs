using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Camera thirdPersonCam;
    [SerializeField] private Camera firstPersonCam;
    [SerializeField] private Gun gun;


    public void SwitchCamera()
    {
        firstPersonCam.gameObject.SetActive(!firstPersonCam.gameObject.activeSelf);
        thirdPersonCam.gameObject.SetActive(!thirdPersonCam.gameObject.activeSelf);
    }

    public void Fire()
    {
        gun.Fire();
    }

}
