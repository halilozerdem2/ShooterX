using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchingState : MovingBaseState
{
    public override void EnterState(MovingStateManager moving)
    {
        moving.currentSpeed = moving.crouchingSpeed;
        moving.anim.SetBool("Crouching", true);
    }


    public override void UpdateState(MovingStateManager moving)
    {
        if (!moving.isCrouching)
        {
            if (!moving.isMoving)
            {
                moving.SwitchState(moving.idle);
            }
            else
            {
                if (moving.isRunning)
                    moving.SwitchState(moving.running);

                else
                    moving.SwitchState(moving.walking);
            }
        }
    }
    public override void ExitState(MovingStateManager moving)
    {
        moving.anim.SetBool("Crouching", false);
    }
}
