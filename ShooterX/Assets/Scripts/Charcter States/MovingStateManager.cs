using System.Collections;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MovingStateManager : MonoBehaviour
{
    [Header("Objects and References")]
    [SerializeField] public FixedJoystick joystick;
    [SerializeField] public Rigidbody playerRb;
    [SerializeField] public Animator anim;

    [Header("Character Attributes")]
    [SerializeField] public float playerRotationSensitivity = 2f;
    [SerializeField] public float rotationMultiplier = 0.1f;

    [Header("Speeds")]
    [SerializeField] public float walkingSpeed;
    [SerializeField] public float runningSpeed;
    [SerializeField] public float crouchingSpeed;
    [HideInInspector] public float currentSpeed;

    [Header("JumpForces")]
    [SerializeField] public float idleJumpForce;
    [SerializeField] public float walkingJumpForce;
    [SerializeField] public float runningJumpForce;
    [HideInInspector] public float currentJumpForce;

    public bool isGrounded;
    public bool isCrouching;
    public bool isMoving;
    public bool isWalking;
    public bool isRunning;

    MovingBaseState currentState;

    public IdleState idle = new IdleState();
    public WalkingState walking = new WalkingState();
    public RunningState running = new RunningState();
    public CrouchingState crouching = new CrouchingState();


    private Rect rotationTouchZone = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);
    private void Start()
    {
        SwitchState(idle);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }
    private void FixedUpdate()
    {
        Move();
        SetRotation();
    }

    public void SwitchState(MovingBaseState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this); 
        }

        currentState = newState; 
        currentState.EnterState(this); 
    }

    public void Jump()
    {
        if (isGrounded)
        {
            //Jump
            playerRb.AddForce(Vector3.up * currentJumpForce);
        }
    }
    private void Move()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * currentSpeed * Time.deltaTime;
        Vector3 worldMovement = transform.TransformDirection(movement);

        //Move
        playerRb.MovePosition(transform.position + worldMovement);
        isMoving = horizontalInput != 0f || verticalInput != 0f;
        Debug.Log(currentState);
        //Debug.Log("Running: " + isRunning + " Crouching: " + isCrouching);

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
}
