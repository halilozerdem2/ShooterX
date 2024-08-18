using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : MovingBaseState
{
    public override void EnterState(MovingStateManager moving)
    {
        moving.isWalking = true;
        moving.currentSpeed = moving.walkingSpeed;
        moving.currentJumpForce = moving.walkingJumpForce;
        moving.anim.SetBool("Walking", true);
    }

    public override void UpdateState(MovingStateManager moving)
    {
        if (!moving.isMoving)
            moving.SwitchState(moving.idle);


        //isRunning deðiþkeni bir buton tarafýndan kontrol edilecek, atamasý o buton üzerinden yapýlacak.
        if (moving.isRunning)
            moving.SwitchState(moving.running);

        //isCrouching deðiþkeni de bir buton tarafýndan kontrol edilecek, atamasý o butün üzerinden yapýlacak.
        if (moving.isCrouching)
        {
            moving.SwitchState(moving.crouching);
        }
    }

    public override void ExitState(MovingStateManager moving)
    {
        moving.isWalking = false;
        moving.anim.SetBool("Walking", false);
    }
}
