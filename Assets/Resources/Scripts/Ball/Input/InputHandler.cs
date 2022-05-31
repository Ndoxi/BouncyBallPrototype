using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    private Vector2 _touchStartPosition;
    private InputActionPhase _touchPhase;

    public Vector2 TouchStartPosition { get { return _touchStartPosition; } }
    public InputActionPhase TouchPhase { get { return _touchPhase; } }


    public void OnTouch(InputAction.CallbackContext context)
    {
        if (context.performed == false) { return; }

        _touchStartPosition = context.ReadValue<Vector2>();

        Debug.Log(_touchStartPosition);
    }


    public void OnTouchHold(InputAction.CallbackContext context)
    {
        _touchPhase = context.phase;
        Debug.Log(context.phase);
    }
}
