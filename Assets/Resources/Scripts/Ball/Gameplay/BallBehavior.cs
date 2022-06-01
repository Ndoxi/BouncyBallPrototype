using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallBehavior : MonoBehaviour
{
    public delegate void LaunchBall(float chargePower);
    public static event LaunchBall ReadyForLaunchEvent;


    [Header("Max charge time")]
    [SerializeField] private float _maxChargeTime = 1.5f;

    private float _currentChargeTime;
    private IEnumerator PreparingForLaunchCoroutine;


    IEnumerator PreparingForLaunch()
    {
        _currentChargeTime = 0;

        while (true)
        {
            _currentChargeTime += Time.deltaTime;
            if (_currentChargeTime >= _maxChargeTime)
            {
                float chargePower = _currentChargeTime / _maxChargeTime;
                ReadyForLaunchEvent?.Invoke(chargePower);

                PreparingForLaunchCoroutine = null;

                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }


    public void StartPrepare()
    {
        PreparingForLaunchCoroutine = PreparingForLaunch(); 
        StartCoroutine(PreparingForLaunchCoroutine);
    }

    
    /// <summary>
    /// Stop launch charge early
    /// </summary>
    public void StorPrepare()
    {
        if (PreparingForLaunchCoroutine == null) { return; }

        StopCoroutine(PreparingForLaunchCoroutine);
        PreparingForLaunchCoroutine = null;

        float chargePower = _currentChargeTime / _maxChargeTime;
        ReadyForLaunchEvent?.Invoke(chargePower);
    }
}