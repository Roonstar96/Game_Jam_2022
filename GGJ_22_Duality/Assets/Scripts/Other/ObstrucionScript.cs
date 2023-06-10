using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstrucionScript : MonoBehaviour
{
    [Header("Player reference")]

    [SerializeField] private MovementCrouch _crouch;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _crouch.Obstructed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _crouch.Obstructed = false;
        }
    }
}
