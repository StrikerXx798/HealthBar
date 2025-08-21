using TMPro;
using UnityEngine;

public class HealthBarText : HealthBar
{
    [SerializeField] private TextMeshProUGUI _barUI;

    private void Start()
    {
        SetText(Health.MaxHealth, Health.MaxHealth);
    }

    protected override void ChangeView(float currentHealth)
    {
        SetText(currentHealth, Health.MaxHealth);
    }

    private void SetText(float currentHealth, float maxHealth)
    {
        _barUI.text = $"{currentHealth:F0}/{maxHealth:F0}";
    }
}