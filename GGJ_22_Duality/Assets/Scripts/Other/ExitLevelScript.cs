using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevelScript : MonoBehaviour
{
    [SerializeField] private bool _isExiting;

    public bool Exiting { get => _isExiting; set => _isExiting = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _isExiting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _isExiting = false;
        }
    }
}
