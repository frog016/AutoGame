using System;

namespace Health
{
    public interface IDamageable
    {
        int Health { get; }
        int MaxHealth { get; }
        event Action<int> Changed;
        void ApplyDamage(int amount);
    }
}
