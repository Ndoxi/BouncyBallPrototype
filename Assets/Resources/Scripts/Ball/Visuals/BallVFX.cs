using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallVFX : MonoBehaviour
{
    [Header("Ball sprite")]
    [SerializeField] private SpriteRenderer _ballSprite;

    [Header("Disable color")]
    [SerializeField] private Color32 _disableBallColor;

    private Color32 _enableBallColor;


    private void Start()
    {
        _enableBallColor = _ballSprite.color;
    }


    public void EnableBall()
    {
        _ballSprite.color = _enableBallColor;
    }


    public void DisableBall()
    {
        _ballSprite.color = _disableBallColor;
    }
}
