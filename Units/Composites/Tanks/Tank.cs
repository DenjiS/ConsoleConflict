using ConsoleConflict.Common.Health;
using ConsoleConflict.Common.Units;
using ConsoleConflict.Common.Weapons;
using System;
using System.Collections.Generic;

namespace ConsoleConflict.Units.Composites.Tanks
{
    internal class Tank : Composite, IDamageble
    {
        private readonly int _mass;
        private readonly Health _health;
        private readonly IWeaponStrategy _weapon;

        public Tank(int health, int capacity, int mass, IWeaponStrategy weapon) : base(capacity)
        {
            _mass = mass;
            _health = new Health(health);

            if (weapon != null)
            {
                _weapon = weapon;
            }
            else
            {
                throw new ArgumentNullException(nameof(weapon));
            }
        }

        public int MaxHealth => _health.Max;

        public int Health => _health.Amount;

        public override int UnitsSize => base.UnitsSize + _mass;

        public override void Attack(IUnitComposite enemy) => _weapon.Attack(enemy);

        public void TakeDamage(int damage)
        {
            _health.Amount -= damage;

            if (_health.Amount == 0)
            {
                GlobalKiller.Dead += Die;
            }
        }

        protected override void Die()
        {
            base.Die();

            foreach (IUnitComposite unit in Units)
            {
                ParentComposite?.Add((Unit)unit);
            }
        }

        public override string GetInformation() =>
            base.GetInformation() + $" health {Health} / {MaxHealth} ||";

        protected override bool CheckOverweight(IUnitComposite unit) =>
            base.UnitsSize + unit.UnitsSize > Capacity;
    }
}
