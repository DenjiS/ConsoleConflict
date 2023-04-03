using ConsoleConflict.Weapons;
using System;
using System.Collections.Generic;

namespace ConsoleConflict.Units.Soldiers
{
    internal class Soldier : Unit, IHealthStrategy
    {
        private readonly Health _health;
        private readonly IAttackStrategy _weapon;

        public Soldier(int health, IAttackStrategy weapon, List<IUnitComposite> parentComposite) : base(parentComposite)
        {
            _health = new Health(health);

            if (weapon != null)
                _weapon = weapon;
            else
                throw new ArgumentNullException(nameof(weapon));
        }

        public int MaxHealth => _health.Max;

        public int Health => _health.Amount;

        public override void Attack(IUnitComposite enemy) => _weapon.Attack(enemy);

        public void TakeDamage(int damage)
        {
            _health.Amount -= damage;

            if (_health.Amount == 0)
                GlobalKiller.Dead += Die;
        }
    }
}