using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PhysicsEntity : Entity // Сущность, способная получать урон
    {
        public delegate void OnDeathEvent(); // Damage type?
        public event OnDeathEvent OnDeath;

        public int MaxHealthPoint;
        int healthPoint;
        public int HealthPoint
        {
            get => healthPoint;
            set
            {
                healthPoint = Math.Clamp(value, 0, MaxHealthPoint); // Overdamage?
                if (healthPoint <= 0)
                    Death();
            }
        }

        protected Rigidbody2D rb;

        override protected void Start()
        {
            base.Start();
            HealthPoint = MaxHealthPoint;
            rb = GetComponent<Rigidbody2D>();
        }
        public override string ToString() => ($"Entity \"{GetType().Name}\": \nHP:{HealthPoint}/{MaxHealthPoint} ");

        public virtual void Death()
        {
            OnDeath?.Invoke();
            DestroyEntity();
        }
        public void DealDamage(int damageCount) => // Damage type?
            HealthPoint -= damageCount;
    }
}