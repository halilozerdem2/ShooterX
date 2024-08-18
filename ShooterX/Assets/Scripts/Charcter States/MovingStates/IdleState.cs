using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovingBaseState
{
    public override void EnterState(MovingStateManager moving)
    {
        moving.currentJumpForce = moving.idleJumpForce;
    }

    public override void ExitState(MovingStateManager moving)
    {

    }

    public override void UpdateState(MovingStateManager moving)
    {
        //isMoving de�i�keninin atamas� MovingStateManagerdaki Move() fonksiyonunda atamas� yap�l�r.
        if (moving.isMoving)
        {
            if (moving.isRunning)
                moving.SwitchState(moving.running);
            else
                moving.SwitchState(moving.walking);

        }
        if (moving.isCrouching)
        {
            moving.SwitchState(moving.crouching);
        }
    }
}
