using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallLauncher : MonoBehaviour
{
    [Header("Script manager")]
    [SerializeField] private BallScriptManager _scriptManager;

    private Vector2 _touchStartPosition;


    public void StartLauncher()
    {
        InputHandler.TouchHoldStartedEvent += PrepareForLaunch;
        InputHandler.TouchHoldEndedEvent += StopPreparingForLaunch;
        BallBehavior.ReadyForLaunchEvent += ReadyForLaunch;
    }


    public void StopLauncher()
    {
        InputHandler.TouchHoldStartedEvent -= PrepareForLaunch;
        InputHandler.TouchHoldEndedEvent -= StopPreparingForLaunch;
        BallBehavior.ReadyForLaunchEvent -= ReadyForLaunch;
    }


    private void PrepareForLaunch(Vector2 position)
    {
        _touchStartPosition = Camera.main.ScreenToWorldPoint(position);
        _scriptManager.BallBehavior.StartPrepare();
    }


    private void StopPreparingForLaunch()
    {
        _scriptManager.BallBehavior.StorPrepare();
    }


    private void ReadyForLaunch(float chargePower)
    {
        _scriptManager.BallPhysic.Launch(_touchStartPosition, chargePower);
    }
}