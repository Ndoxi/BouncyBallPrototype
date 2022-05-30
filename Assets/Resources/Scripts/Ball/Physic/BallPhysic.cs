using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallPhysic : MonoBehaviour
{
    [Header("Ground physic layer")]
    [SerializeField] private LayerMask _groundLayer;

    [Header("Ball rigidbody & collider")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private CircleCollider2D _circleCollider;

    private bool _isGrounded;
    private bool _isTouchingGround;
    private float _fallTime;

    public bool IsGrounded { get { return _isGrounded; } }
    public float FallTime {  get { return _fallTime; } }


    private void Update()
    {
        if (_isTouchingGround == false)
        {
            _fallTime += Time.deltaTime;
        } else
        {
            _fallTime = 0;
        }
    }


    private void FixedUpdate()
    {
        _isTouchingGround = Physics2D.OverlapCircle(_circleCollider.bounds.center, _circleCollider.radius, _groundLayer);

        if (_rigidbody.velocity.magnitude <= 0.25f && _isTouchingGround)
        {
            _isGrounded = true;
        } else
        {
            _isGrounded = false;
        }
    }
}