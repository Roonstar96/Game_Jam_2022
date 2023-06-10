using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOneWay : MonoBehaviour
{
    [Header("Platform settings")]
    [SerializeField] private float _speed;
    [SerializeField] private ButtonGeneric _button;    
    private float _timer;

    [Header("Platform Transforms")]
    [SerializeField] private Transform _platformPos;
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;

    private void Awake()
    {
        _platformPos.transform.position = _startPos.position;
    }

    void Update()
    {
        if (_button.Pressed)
        {
            StartCoroutine(MovePlatform());
        }
    }

    private IEnumerator MovePlatform()
    {
        _timer = float.Epsilon;

        while (_timer < _speed)
        {
            Vector2 newPos = Vector2.Lerp(_platformPos.transform.position, _endPos.position, _timer / _speed);
            _platformPos.transform.position = newPos;
            _timer += Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }
    }
}
