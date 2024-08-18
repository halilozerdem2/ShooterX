using System.Collections;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    [SerializeField] Rigidbody playerRb;
    [SerializeField] Animator anim;

    [SerializeField] float walkingSpeed = 10f, runningSpeed=15f,currentSpeed;
    [SerializeField] float JumpForce = 10f;
    [SerializeField] float playerRotationSensitivity = 2f;
    [SerializeField] float rotationMultiplier = 0.1f;

    public bool isGrounded;
    public bool isCrouching;
    public bool isRunning;

    private Rect rotationTouchZone = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);

    private void FixedUpdate()
    {
        Move();
        SetRotation();
    }

    public void Jump()
    {
        if (isGrounded)
        {
            StartCoroutine(Jumping());
            anim.SetTrigger("Jump");
        }
    }
    public IEnumerator Jumping()
    {
        yield return new WaitForSeconds(0.5f);
        playerRb.AddForce(Vector3.up * JumpForce);
    }
    private void Move()
    { 
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        if (!isRunning)
        {
            currentSpeed = walkingSpeed;
        }
        else
            currentSpeed = runningSpeed;
            
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * currentSpeed * Time.deltaTime;
            Vector3 worldMovement = transform.TransformDirection(movement);

        playerRb.MovePosition(transform.position + worldMovement);

        bool isMoving = horizontalInput != 0f || verticalInput != 0f;
        anim.SetFloat("vInput", verticalInput);
        anim.SetFloat("hInput", horizontalInput);
    }

    private void SetRotation()
    {
        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                if (rotationTouchZone.Contains(touch.position))
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                        float rotationAmountX = touch.deltaPosition.x * rotationMultiplier;
                        float rotationAmountY = touch.deltaPosition.y * rotationMultiplier;

                        transform.Rotate(0f, rotationAmountX * playerRotationSensitivity, 0f, Space.World);
                        transform.Rotate(-rotationAmountY * playerRotationSensitivity, 0f, 0f, Space.Self);
                    }
                }
            }
        }
    }

    public void Crouch()
    {
        isCrouching = true;
        anim.SetBool("Crouching", true); 
    }
    public void GetUp()
    {
        isCrouching = false;
        anim.SetBool("Crouching", false);
    }

    public void Run()
    {
        isRunning= true;
        anim.SetBool("Running", true);
    }

    public void StopRunning()
    {
        isRunning = false;
        currentSpeed = walkingSpeed;
        anim.SetBool("Running", false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
