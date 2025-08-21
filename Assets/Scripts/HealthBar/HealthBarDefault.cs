using UnityEngine;
using UnityEngine.UI;

public class HealthBarDefault : HealthBar
{
    private const float MaxHealthView = 1f;

    [SerializeField] private Image _fillBar;

    protected Image FillBar => _fillBar;

    private void Start()
    {
        _fillBar.fillAmount = MaxHealthView;
    }

    protected override void ChangeView(float currentHealth)
    {
        var healthPercentage = currentHealth / Health.MaxHealth;
        _fillBar.fillAmount = healthPercentage;
    }
}