using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    private float _currentValue;
    private Coroutine _coroutine;
    private bool _isRunning = false;
    private int _clickOnLeftMouseButton = 0;

    public event Action Changed;

    public bool IsRunning => _isRunning;
    public float Value => _currentValue;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_clickOnLeftMouseButton))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            else
            {
                _coroutine = StartCoroutine(IncreaseValue());
                _isRunning = true;
            }
        }
    }

    private IEnumerator IncreaseValue()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (enabled)
        {
            _currentValue += 1;
            Changed();

            yield return wait;
        }
    }
}
