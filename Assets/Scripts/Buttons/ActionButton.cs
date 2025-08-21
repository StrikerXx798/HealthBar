using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    private const float MinValue = 0f;

    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private Button _button;
    [SerializeField] private float _changingValue;
    
    protected float ChangingValue => _changingValue;

    private void Start()
    {
        _label.text = $"{_label.text} ({_changingValue})";
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickHandler);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickHandler);
    }

    private void OnValidate()
    {
        _changingValue = Mathf.Clamp(_changingValue, MinValue, float.MaxValue);
    }

    protected virtual void OnClickHandler()
    {
    }
}