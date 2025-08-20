using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const float MinHealth = 0f;

    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public event Action<float> HealthChanged;

    public float MaxHealth { get; private set; }

    private void Awake()
    {
        MaxHealth = _maxHealth;
        _currentHealth = _maxHealth;
    }

    public void DealDamage(float damage)
    {
        var newHealth = _currentHealth - damage;

        if (newHealth <= MinHealth)
        {
            _currentHealth = MinHealth;
            HealthChanged?.Invoke(MinHealth);

            return;
        }

        _currentHealth = newHealth;
        HealthChanged?.Invoke(newHealth);
    }

    public void Heal(float heal)
    {
        var newHealth = _currentHealth + heal;
        _currentHealth = newHealth >= MaxHealth ? MaxHealth : newHealth;
        HealthChanged?.Invoke(_currentHealth);
    }
}