using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJump : MonoBehaviour
{
    [Header("Movment variables")]
    [SerializeField] private float _direction;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private bool _facingRight;
    
    [Header("Componenets")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;


    private void Awake()
    {
        _facingRight = true; 
    }

    private void Update()
    {
        _direction = Input.GetAxisRaw("Horizontal1");

        if (Input.GetButtonDown("Jump") && checkIsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);  
        }

        FlipPlayer();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_direction * _speed, _rb.velocity.y);
    }

    private bool checkIsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _ground);
    }

    private void FlipPlayer()
    {
        if (_facingRight && _direction < 0f || !_facingRight && _direction > 0f)
        {
            _facingRight = !_facingRight;
            Vector3 newLocal = gameObject.transform.localScale;
            newLocal.x *= -1;
            gameObject.transform.localScale = newLocal;
        }
    }
}
