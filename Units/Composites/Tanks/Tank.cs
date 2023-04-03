using ConsoleConflict.Weapons;
using System;
using System.Collections.Generic;

namespace ConsoleConflict.Units.Composites.Tanks
{
    internal class Tank : Composite, IHealthStrategy
    {
        private readonly int _mass;
        private readonly Health _health;
        private readonly IAttackStrategy _weapon;

        public Tank(int health, int capacity, int mass, IAttackStrategy weapon, List<IUnitComposite> parentComposite) : base(capacity, parentComposite)
        {
            _mass = mass;
            _health = new Health(health);

            if (weapon != null)
                _weapon = weapon;
            else
                throw new ArgumentNullException(nameof(weapon));
        }

        public int MaxHealth => _health.Max;

        public int Health => _health.Amount;

        public override int UnitsAmount => base.UnitsAmount + _mass;

        public override void Attack(IUnitComposite enemy) => _weapon.Attack(enemy);

        public void TakeDamage(int damage)
        {
            _health.Amount -= damage;

            if (_health.Amount == 0)
                GlobalKiller.Dead += Die;
        }

        protected override void Die()
        {
            ParentComposite.AddRange(Units);
            base.Die();
        }
    }
}
