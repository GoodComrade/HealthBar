using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;
    private Slider _slider;
    private float _changeSpeed = 10;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        InitValues();
        StartCoroutine(UpdateValue());
    }

    private void InitValues()
    {
        _slider.maxValue = _health.MaxHealth;
        _slider.value = _health.MaxHealth;
    }

    public IEnumerator UpdateValue()
    {
        while(true)
        {
            if(_slider.value != _health.HealthAmount)
                _slider.value = Mathf.MoveTowards(_slider.value, _health.HealthAmount, Time.deltaTime * _changeSpeed);

            yield return null;
        }
    }
}
