using UnityEngine;

public class DamageButton : ActionButton
{
    [SerializeField] private Health _health;

    protected override void OnClickHandler()
    {
        _health.DealDamage(ChangingValue);
    }
}