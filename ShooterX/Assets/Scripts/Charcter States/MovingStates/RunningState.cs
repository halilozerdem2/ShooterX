using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : MovingBaseState
{
    public override void EnterState(MovingStateManager moving)
    {
        //isRunning de�i�keni buton �zerinden kontrol edilecek. Atamas� burada yap�lmayacak.
        //moving.isRunning = true;
        moving.currentSpeed = moving.runningSpeed;
        moving.currentJumpForce = moving.runningJumpForce;
        moving.anim.SetBool("Running", true);

    }

    public override void ExitState(MovingStateManager moving)
    {
        moving.anim.SetBool("Running", false);
    }

    public override void UpdateState(MovingStateManager moving)
    {
        if(!moving.isRunning)
        {
            if(!moving.isMoving)
            {
                moving.SwitchState(moving.idle);
            }
            else
                moving.SwitchState(moving.walking);
        }
    }
}
