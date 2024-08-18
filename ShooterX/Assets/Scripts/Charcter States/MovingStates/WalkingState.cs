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


        //isRunning de�i�keni bir buton taraf�ndan kontrol edilecek, atamas� o buton �zerinden yap�lacak.
        if (moving.isRunning)
            moving.SwitchState(moving.running);

        //isCrouching de�i�keni de bir buton taraf�ndan kontrol edilecek, atamas� o but�n �zerinden yap�lacak.
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
