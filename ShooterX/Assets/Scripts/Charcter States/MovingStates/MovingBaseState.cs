
public abstract class MovingBaseState
{
    public abstract void EnterState(MovingStateManager moving);
    public abstract void UpdateState(MovingStateManager moving);
    public abstract void ExitState(MovingStateManager moving);

}
