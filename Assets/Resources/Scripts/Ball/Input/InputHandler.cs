using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    public delegate void TouchHoldStarted(Vector2 touchStartPosition);
    public static event TouchHoldStarted TouchHoldStartedEvent;

    public delegate void TouchHoldEnded();
    public static event TouchHoldEnded TouchHoldEndedEvent;


    private Vector2 _touchStartPosition;

    public Vector2 TouchStartPosition { get { return _touchStartPosition; } }


    public void OnTouch(InputAction.CallbackContext context)
    {
        if (context.performed == false) { return; }

        _touchStartPosition = context.ReadValue<Vector2>();
    }


    public void OnTouchHold(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                {
                    TouchHoldStartedEvent?.Invoke(_touchStartPosition);
                    break;
                }

            default:
                {
                    TouchHoldEndedEvent?.Invoke();
                    break;
                }
        }
    }
}
