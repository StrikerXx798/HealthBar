using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private Button _button;
    [SerializeField] private float _healValue;
    [SerializeField] private Health _health;

    private void Start()
    {
        _textMeshPro.text = $"{_textMeshPro.text} ({_healValue})";
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
        _health.Heal(_healValue);
    }
}