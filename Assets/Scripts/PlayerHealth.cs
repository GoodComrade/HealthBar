using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerHealthView _healthView;
    [SerializeField] private Button _healthButton;
    [SerializeField] private Button _damageButton;
    [SerializeField] private float _healthAmount;

    private float _maxHealth;
    private float _valueToChange = 10;


    // Start is called before the first frame update
    void Start()
    {
        _maxHealth = _healthAmount;
        _healthView.InitValues(_maxHealth);
        _healthButton.onClick.AddListener(AddHealth);
        _damageButton.onClick.AddListener(AddDamage);
    }

    private void AddHealth()
    {
        if (_healthAmount != _maxHealth)
        {
            _healthAmount += _valueToChange;
            StartCoroutine(_healthView.UpdateValue(_healthAmount));
        }
    }

    private void AddDamage()
    {
        if (_healthAmount != 0)
        {
            _healthAmount -= _valueToChange;
            StartCoroutine(_healthView.UpdateValue(_healthAmount));
        }
    }
}
