using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPressure : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _platformPos;
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;

    private float _timer;

    private void Awake()
    {
        _platformPos.position = _startPos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(MoveDown());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(MoveUp());
        }
    }

    private IEnumerator MoveDown()
    {
        _timer = float.Epsilon;

        while (_timer < _speed)
        {
            Vector3 newPos = Vector3.Lerp(_platformPos.position, _endPos.position, _timer / _speed);
            _platformPos.position = newPos;
            _timer += Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator MoveUp()
    {
        _timer = float.Epsilon;

        while (_timer < _speed)
        {
            Vector3 newPos = Vector3.Lerp(_platformPos.position, _startPos.position, _timer / _speed);
            _platformPos.position = newPos;
            _timer += Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }
    }
}
