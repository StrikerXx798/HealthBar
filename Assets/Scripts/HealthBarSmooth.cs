using UnityEngine;
using System.Collections;

public class HealthBarSmooth : MonoBehaviour
{
    private const float MinDeltaWidth = 0.01f;

    [SerializeField] private RectTransform _emptyBar;
    [SerializeField] private RectTransform _filledBar;
    [SerializeField] private Health _health;
    [SerializeField] private float _changeSpeed;

    private readonly Vector2 _defaultPosition = new Vector2(0, 0.5f);
    private Coroutine _currentChangeCoroutine;

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
        var targetWidth = _emptyBar.sizeDelta.x * healthPercentage;

        if (_currentChangeCoroutine != null)
        {
            StopCoroutine(_currentChangeCoroutine);
        }

        _currentChangeCoroutine = StartCoroutine(ChangeToSmooth(targetWidth));
    }

    private IEnumerator ChangeToSmooth(float targetWidth)
    {
        while (Mathf.Abs(_filledBar.sizeDelta.x - targetWidth) > MinDeltaWidth)
        {
            _filledBar.sizeDelta =
                new Vector2(Mathf.MoveTowards(_filledBar.sizeDelta.x, targetWidth, _changeSpeed * Time.deltaTime),
                    _emptyBar.sizeDelta.y);

            yield return null;
        }

        _filledBar.sizeDelta = new Vector2(targetWidth, _emptyBar.sizeDelta.y);
    }
}