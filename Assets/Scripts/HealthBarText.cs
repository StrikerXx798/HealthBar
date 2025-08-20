using TMPro;
using UnityEngine;

public class HealthBarText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private Health _health;

    private void Start()
    {
        SetText(_health.MaxHealth, _health.MaxHealth);
    }

    private void OnEnable()
    {
        _health.HealthChanged += ChangeView;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ChangeView;
    }

    private void ChangeView(float currentHealth)
    {
        SetText(currentHealth, _health.MaxHealth);
    }

    private void SetText(float currentHealth, float maxHealth)
    {
        _textMeshPro.text = $"{currentHealth:F0}/{maxHealth:F0}";
    }
}