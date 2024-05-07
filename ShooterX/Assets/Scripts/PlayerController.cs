using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    [SerializeField] Rigidbody playerRb;

    [SerializeField] float playerMovingSpeed = 10f;
    [SerializeField] float playerRotationSensitivity = 10f;
    private Vector3 direction;

    private void Awake()
    {
        joystick= FindObjectOfType<FixedJoystick>();
        playerRb= GetComponent<Rigidbody>();
    }
    private void Update()
    {
        direction = new Vector3(playerMovingSpeed * joystick.Horizontal, playerRb.velocity.y, playerMovingSpeed * joystick.Vertical);
        
    }
    private void Move()
    {
        playerRb.velocity= direction;
    }

   private void SetRotation()
    {

    }
    private void FixedUpdate()
    {
        Move();   
    }
}
