using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoor : MonoBehaviour
{
    [Header("Door Variables")]
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _doorObj;
    [SerializeField] private Transform _openPos;
    [SerializeField] private Transform _closePos;

    private float _timer;

    private void Awake()
    {
        _doorObj.transform.position = _closePos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(OpenDoor());
        }
    }
    private IEnumerator OpenDoor()
    {
        _timer = float.Epsilon;

        while (_timer < _speed)
        {
            Vector2 newPos = Vector2.Lerp(_doorObj.transform.position, _openPos.position, _timer / _speed);
            _doorObj.transform.position = newPos;
            _timer += Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }
    }
}
