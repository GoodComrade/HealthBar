using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _healthAmount;

    public UnityAction OnHealthChanged;

    private float _maxHealth;

    public float HealthAmount => _healthAmount;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _maxHealth = _healthAmount;
    }

    public void AddHealth(float valueToChange)
    {
        _healthAmount += valueToChange;

        if (_healthAmount > _maxHealth)
            _healthAmount = _maxHealth;

        OnHealthChanged?.Invoke();
    }

    public void AddDamage(float valueToChange)
    {
        _healthAmount -= valueToChange;

        if (_healthAmount < 0)
            _healthAmount = 0;

        OnHealthChanged?.Invoke();
    }
}
