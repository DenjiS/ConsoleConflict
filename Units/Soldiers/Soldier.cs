using ConsoleConflict.Common.Health;
using ConsoleConflict.Common.Units;
using ConsoleConflict.Common.Weapons;
using System;

namespace ConsoleConflict.Units.Soldiers
{
    internal class Soldier : Unit, IDamageble
    {
        private readonly Health _health;
        private readonly IWeaponStrategy _weapon;

        public Soldier(int health, IWeaponStrategy weapon)
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

        public override string GetInformation() =>
            base.GetInformation() + $" health {Health} / {MaxHealth} ||";
    }
}