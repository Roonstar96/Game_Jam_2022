using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private bool _isPressed;

    public bool Pressed { get => _isPressed; set => _isPressed = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _isPressed = true;
        }
    }
}
