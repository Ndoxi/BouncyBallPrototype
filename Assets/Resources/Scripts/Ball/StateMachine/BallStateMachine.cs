using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallStateMachine : MonoBehaviour
{
    private UnstableState _unstableState;
    private StableState _stableState;

    private BaseState _currentState;

    public UnstableState UnstableState { get { return _unstableState; } }
    public StableState StableState { get { return _stableState; } }


    private void Start()
    {
        _unstableState = new UnstableState(this);
        _stableState = new StableState(this);

        _currentState = _unstableState;
    }


    public void SetNewState(BaseState newState)
    {
        if (_currentState == newState) { return; }

        _currentState.OnStateExit();
        _currentState = newState;
        newState.OnStateEnter();
    }
}
