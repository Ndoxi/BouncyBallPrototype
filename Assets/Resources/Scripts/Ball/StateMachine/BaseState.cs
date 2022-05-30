public abstract class BaseState
{
    protected BallStateMachine _context;

    public BaseState(BallStateMachine context)
    {
        this._context = context;
    }



    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public virtual void LateUpdateState() { }

    protected abstract void ProcessTransitions();
    protected abstract void StateBehavior();


    public void UpdateState() 
    {
        ProcessTransitions();
        UpdateState();
    }
}
