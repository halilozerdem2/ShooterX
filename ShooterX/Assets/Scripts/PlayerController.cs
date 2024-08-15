using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    [SerializeField] Rigidbody playerRb;

    [SerializeField] Animator anim;
    [SerializeField] float playerMovingSpeed = 10f;
    [SerializeField] float playerRotationSensitivity = 2f;
    [SerializeField] float rotationMultiplier = 0.1f;

    Rect rotationTouchZone = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);

    private void FixedUpdate()
    {
        Move();
        SetRotation();
    }

    private void Move()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * playerMovingSpeed * Time.deltaTime;
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
                        transform.GetChild(0).Rotate(-rotationAmountY * playerRotationSensitivity, 0f, 0f, Space.Self);
                    }
                }
            }
        }
    }

}
