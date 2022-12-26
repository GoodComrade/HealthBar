using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;
    private Slider _slider;
    private float _changeSpeed = 10;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        InitValues();
    }

    private void OnEnable()
    {
        _health.OnHealthChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _health.OnHealthChanged -= ChangeValue;
    }

    private void InitValues()
    {
        _slider.maxValue = _health.MaxHealth;
        _slider.value = _health.MaxHealth;
    }

    private void ChangeValue()
    {
        StartCoroutine(UpdateValue());
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
