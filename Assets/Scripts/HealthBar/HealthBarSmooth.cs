using UnityEngine;
using System.Collections;

public class HealthBarSmooth : HealthBarDefault
{
    private const float DefaultElapsedTime = 0f;

    [SerializeField] private float _changeSpeed;

    private Coroutine _currentChangeCoroutine;
    
    private IEnumerator ChangeToSmooth(float targetFillAmount)
    {
        var startFillAmount = FillBar.fillAmount;
        var elapsedTime = DefaultElapsedTime;
        var duration = Mathf.Abs(targetFillAmount - startFillAmount) / _changeSpeed;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            var t = Mathf.Clamp01(elapsedTime / duration);
            FillBar.fillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, t);

            yield return null;
        }

        FillBar.fillAmount = targetFillAmount;
    }

    protected override void ChangeView(float currentHealth)
    {
        var healthPercentage = currentHealth / Health.MaxHealth;

        if (_currentChangeCoroutine != null)
        {
            StopCoroutine(_currentChangeCoroutine);
        }

        _currentChangeCoroutine = StartCoroutine(ChangeToSmooth(healthPercentage));
    }
}