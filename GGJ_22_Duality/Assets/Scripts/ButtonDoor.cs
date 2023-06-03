using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    [Header("Door Variables")]
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _doorObj;
    [SerializeField] private Transform _openPos;
    [SerializeField] private Transform _closePos;

    [Header("Button references")]
    [SerializeField] private GameObject[] _buttons;
    
    private float _timer;

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
            var bb = _buttons[i].GetComponent<Button>().Pressed;

            if (!bb)
            {
                break;
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
}
