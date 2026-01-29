using UnityEngine;
using UnityEngine.UI;

public class SliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private ReactiveVariable<float> _current;
    private ReactiveVariable<float> _max;

    public void Initialize(ReactiveVariable<float> current, ReactiveVariable<float> max)
    {
        _current = current;
        _max = max;

        _current.Changed += OnCurrentChanged;
        _max.Changed += OnMaxChanged;

        UpdateValue(_current.Value, _max.Value);
    }


    private void OnDestroy()
    {
        _current.Changed -= OnCurrentChanged;
        _max.Changed -= OnMaxChanged;
    }

    private void OnCurrentChanged(float oldValue, float newValue) =>UpdateValue(newValue, _max.Value);
    private void OnMaxChanged(float arg1, float newValue) => UpdateValue(_current.Value, newValue);

    private void UpdateValue(float currentValue, float maxValue) => _slider.value = currentValue / maxValue;
}
