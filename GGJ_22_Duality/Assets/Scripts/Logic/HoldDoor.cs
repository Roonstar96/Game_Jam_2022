using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldDoor : MonoBehaviour
{
    [Header("Door Variables")]
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _doorObj;
    [SerializeField] private Transform _openPos;
    [SerializeField] private Transform _closePos;

    [Header("Button references")]
    [SerializeField] private GameObject[] _buttons;

    private float _timer;

    void Start()
    {
        
    }

    private void Awake()
    {
        _doorObj.transform.position = _closePos.position;
    }

    private void Update()
    {
        ButtonCheck();
    }

    private void ButtonCheck()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            var bb = _buttons[i].GetComponent<ButtonGeneric>().Pressed;

            if (!bb)
            {
                StartCoroutine(CloseDoor());
            }
            else
            {
                StartCoroutine(OpenDoor());
            }
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

    private IEnumerator CloseDoor()
    {
        _timer = float.Epsilon;

        while (_timer < _speed)
        {
            Vector2 newPos = Vector2.Lerp(_doorObj.transform.position, _closePos.position, _timer / _speed);
            _doorObj.transform.position = newPos;
            _timer += Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }
    }
}
