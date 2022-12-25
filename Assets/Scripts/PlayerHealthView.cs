using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    private Slider _slider;
    private float _changeSpeed = 10;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void InitValues(float maxValue)
    {
        _slider.maxValue = maxValue;
        _slider.value = maxValue;
    }

    public IEnumerator UpdateValue(float targetValue)
    {
        while(_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, Time.deltaTime * _changeSpeed);
            yield return null;
        }
    }
}
