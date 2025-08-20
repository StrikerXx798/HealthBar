using System;
using UnityEngine;

public class HealthBarDefault : MonoBehaviour
{
    [SerializeField] private RectTransform _emptyBar;
    [SerializeField] private RectTransform _filledBar;
    [SerializeField] private Health _health;

    private readonly Vector2 _defaultPosition = new Vector2(0, 0.5f);

    private void Start()
    {
        _filledBar.pivot = _defaultPosition;
        _filledBar.anchorMin = _defaultPosition;
        _filledBar.anchorMax = _defaultPosition;
        _filledBar.anchoredPosition = Vector2.zero;
        _filledBar.sizeDelta = _emptyBar.sizeDelta;
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
        var healthPercentage = currentHealth / _health.MaxHealth;
        _filledBar.sizeDelta = new Vector2(_emptyBar.sizeDelta.x * healthPercentage, _emptyBar.sizeDelta.y);
    }
}