using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private float _damageValue;
    [SerializeField] private Health _health;

    private void Start()
    {
        _textMeshPro.text = $"{_textMeshPro.text} ({_damageValue})";
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickHandler);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickHandler);
    }

    private void OnClickHandler()
    {
        _health.DealDamage(_damageValue);
    }
}