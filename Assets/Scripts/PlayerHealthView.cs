using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;

    private Slider _slider;
    private Coroutine _updateValue;
    private float _changeSpeed = 10;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        InitValues();
    }

    private void OnEnable()
    {
        _health.HealthChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ChangeValue;
    }

    private void InitValues()
    {
        _slider.maxValue = _health.MaxHealth;
        _slider.value = _health.MaxHealth;
    }

    private void ChangeValue()
    {
        if(_updateValue != null)
            StopCoroutine(_updateValue);

        _updateValue = StartCoroutine(UpdateValue());
    }

    private IEnumerator UpdateValue()
    {
        while(_slider.value != _health.HealthAmount)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.HealthAmount, Time.deltaTime * _changeSpeed);
            yield return null;
        }
    }
}
