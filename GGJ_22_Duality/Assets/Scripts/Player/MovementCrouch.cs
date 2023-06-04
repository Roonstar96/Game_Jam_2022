using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCrouch : MonoBehaviour
{
    [Header("Movment variables")]
    [SerializeField] private float _direction;
    [SerializeField] private float _speed;
    [SerializeField] private bool _facingRight;

    [Header("Componenets")]
    [SerializeField] private Transform _trans;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private BoxCollider2D _box2D;

    private void Awake()
    {
        _facingRight = true;
    }

    private void Update()
    {
        _direction = Input.GetAxisRaw("Horizontal2");

        FlipPlayer();
        isCrouching();
    }

    private void FixedUpdate()
    { 
        _rb.velocity = new Vector2(_direction * _speed, _rb.velocity.y);
    }

    private void isCrouching()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            _trans.localScale = new Vector3 (1 , 0.5f, 1);
            //_box2D.size = new Vector2(1, 0.5f);
            //_box2D.offset = new Vector2(0, -0.25f);
        }
        if (Input.GetButtonUp("Crouch"))
        {
            _trans.localScale = new Vector3(1, 1, 1);
            //_box2D.size = new Vector2(1, 1);
            //_box2D.offset = new Vector2(0, 0);
        }
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

