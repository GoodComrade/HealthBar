using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Button _healthButton;
    [SerializeField] private Button _damageButton;
    [SerializeField] private float _healthAmount;

    private float _maxHealth;
    private float _valueToChange = 10;

    public float HealthAmount => _healthAmount;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _maxHealth = _healthAmount;
        _healthButton.onClick.AddListener(AddHealth);
        _damageButton.onClick.AddListener(AddDamage);
    }

    private void AddHealth()
    {
        if (_healthAmount != _maxHealth)
            _healthAmount += _valueToChange;
    }

    private void AddDamage()
    {
        if (_healthAmount != 0)
            _healthAmount -= _valueToChange;
    }
}
