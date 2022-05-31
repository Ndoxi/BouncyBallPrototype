using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallScriptManager : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputHandler _inputHandler;

    [Header("Physics")]
    [SerializeField] private BallPhysic _physics;


    public InputHandler InputHandler { get { return _inputHandler; } }
    public BallPhysic BallPhysic { get { return _physics; } }
}