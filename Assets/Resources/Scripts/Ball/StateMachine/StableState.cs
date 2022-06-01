using UnityEngine;


public class StableState : BaseState
{
    public StableState(BallStateMachine context) : base(context) { }

    protected override void ProcessTransitions()
    {
    }

    protected override void StateBehavior()
    {
    }


    public override void OnStateEnter()
    {
        BallPhysic.ExitGrounded += ExitState;

        _context.ScriptManager.Launcher.StartLauncher();
        _context.ScriptManager.BallVFX.EnableBall();
    }


    public override void OnStateExit()
    {
        BallPhysic.ExitGrounded -= ExitState;

        _context.ScriptManager.Launcher.StopLauncher();
    }


    private void ExitState()
    {
        UnstableState unstableState = _context.UnstableState;
        _context.SetNewState(unstableState);
    }
}
