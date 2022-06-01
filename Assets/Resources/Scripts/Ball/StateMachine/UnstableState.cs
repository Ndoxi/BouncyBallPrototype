using UnityEngine;


public class UnstableState : BaseState
{
    public UnstableState(BallStateMachine context) : base(context) { }


    protected override void ProcessTransitions()
    {
    }

    protected override void StateBehavior()
    {
    }


    public override void OnStateEnter()
    {
        BallPhysic.EnterGrounded += ExitState;

        _context.ScriptManager.BallVFX.DisableBall();
    }


    public override void OnStateExit()
    {
        BallPhysic.EnterGrounded -= ExitState;
    }


    private void ExitState()
    {
        StableState stableState = _context.StableState;
        _context.SetNewState(stableState);
    }
}