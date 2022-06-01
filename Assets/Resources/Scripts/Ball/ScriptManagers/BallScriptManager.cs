using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallScriptManager : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputHandler _inputHandler;

    [Header("Physics")]
    [SerializeField] private BallPhysic _physics;

    [Header("VFX")]
    [SerializeField] private BallVFX _ballVFX;

    [Header("Ball behavoir")]
    [SerializeField] private BallBehavior _behavior;

    [Header("Ball launcher")]
    [SerializeField] private BallLauncher _launcher;


    public InputHandler InputHandler { get { return _inputHandler; } }
    public BallPhysic BallPhysic { get { return _physics; } }
    public BallVFX BallVFX { get { return _ballVFX; } }
    public BallBehavior BallBehavior { get { return _behavior; } }
    public BallLauncher Launcher { get { return _launcher; } }
}