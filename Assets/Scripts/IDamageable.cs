using UnityEngine;

public interface IDamageable
{
    public float Health { get; }

    public bool TryApplyDamage(float damage);
}