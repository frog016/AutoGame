using System;
using UnityEngine;

namespace Health
{
    public class DamageableObject : IDamageable
    {
        public int Health { get; private set; }
        public int MaxHealth { get; }
        public event Action<int> Changed;

        public DamageableObject(int health)
        {
            Health = health;
            MaxHealth = health;
        }

        public void ApplyDamage(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException();

            var health = Mathf.Max(0, Health - amount);
            Health = health;
            Changed?.Invoke(Health);
        }
    }
}