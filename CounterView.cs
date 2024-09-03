using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Animator _counterAnimator;
    [SerializeField] private AnimationClip _counterPulseAnimation;

    private void OnEnable()
    {
        _counter.Changed += PrintCounter;
    }

    private void OnDisable()
    {
        _counter.Changed -= PrintCounter;
    }

    private void PrintCounter()
    {
        _counterText.text = _counter.Value.ToString();

        if (_counter.IsRunning)
            _counterAnimator.Play(_counterPulseAnimation.name);
    }
}
