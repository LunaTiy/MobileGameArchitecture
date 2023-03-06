using System;

namespace CodeBase.Logic
{
    public interface IHealth
    {
        event Action HealthChanged;
        float CurrentHp { get;}
        float MaxHp { get; }
        void TakeDamage(float damage);
    }
}