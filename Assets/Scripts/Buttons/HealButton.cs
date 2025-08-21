using UnityEngine;

public class HealButton : ActionButton
{
    [SerializeField] private Health _health;

    protected override void OnClickHandler()
    {
        _health.Heal(ChangingValue);
    }
}