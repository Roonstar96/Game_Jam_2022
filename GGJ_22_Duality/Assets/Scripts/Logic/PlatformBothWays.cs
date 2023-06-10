using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBothWays : MonoBehaviour
{
    [Header("Platform Variables")]
    [SerializeField] private float _speed;   
    //[SerializeField] private bool _platActive;
    [SerializeField] private Transform _platformPos;

    [Header("Platform Positions")]
    [SerializeField] private Transform _leftPos;
    [SerializeField] private Transform _rightPos;
    [SerializeField] private ButtonGeneric _button;

    private float _timer;

    private void Awake()
    {
        _platformPos.transform.position = _rightPos.position;
    }

    void Update()
    {
        if (_button.Pressed)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        if (_platformPos.position == _rightPos.position)
        {
            StartCoroutine(MoveLeft());
        }
        else if (_platformPos.position == _leftPos.position)
        {
            StartCoroutine(MoveRight());
        }
    }

    private IEnumerator MoveLeft()
    {
        _timer = float.Epsilon;

        while (_timer < _speed)
        {
            Vector3 newPos = Vector3.Lerp(_platformPos.transform.position, _leftPos.position, _timer / _speed);
            _platformPos.transform.position = newPos;
            _timer += Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator MoveRight()
    {
        _timer = float.Epsilon;

        while (_timer < _speed)
        {
            Vector3 newPos = Vector3.Lerp(_platformPos.transform.position, _rightPos.position, _timer / _speed);
            _platformPos.transform.position = newPos;
            _timer += Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }
    }
}