using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallPhysic : MonoBehaviour
{
    public delegate void Grounded();
    public static event Grounded EnterGrounded;
    public static event Grounded ExitGrounded;


    [Header("Ground physic layer")]
    [SerializeField] private LayerMask _groundLayer;

    [Header("Ball rigidbody & collider")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private CircleCollider2D _circleCollider;

    [Header("Ball launch force")]
    [SerializeField] private float _forceAmount;

    private bool _isGrounded = true;
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

        if (_isTouchingGround) //_rigidbody.velocity.magnitude <= 0.25f && 
        {
            if (_isGrounded == false)
            {
                EnterGrounded?.Invoke();
            }

            _isGrounded = true;
        } else
        {
            if (_isGrounded)
            {
                ExitGrounded?.Invoke();
            }
            _isGrounded = false;
        }
    }


    /// <summary>
    /// Launch ball wiht given force (ForceMode = Impulse)
    /// </summary>
    public void Launch(Vector2 position, float charge)
    {
        charge = Mathf.Clamp(charge, 0.2f, 1);
        Vector2 force = (_rigidbody.position - position).normalized * _forceAmount * charge;

        _rigidbody.AddForce(force, ForceMode2D.Impulse);
    }
}