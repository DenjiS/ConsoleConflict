using ConsoleConflict.Weapons;
using System;
using System.Collections.Generic;

namespace ConsoleConflict.Units.Soldiers
{
    internal class Soldier : IUnitComposite, IDamageble
    {
        private readonly Health _health;
        private readonly IWeapon _weapon;
        private readonly List<IUnitComposite> _enlistedThis = new();
        private readonly List<IUnitComposite> _parentComposite;
        private bool _isReloading = false;

        public Soldier(int health, IWeapon weapon, List<IUnitComposite> parentComposite)
        {
            _health = new Health(health);

            if (weapon != null)
                _weapon = weapon;
            else
                throw new ArgumentNullException(nameof(weapon));

            _enlistedThis.Add(this);
            _parentComposite = parentComposite;
        }

        public int MaxHealth => _health.Max;

        public int Health => _health.Amount;

        public IReadOnlyList<IUnitComposite> Units => _enlistedThis;

        public void Attack(IUnitComposite enemy)
        {
            if (_isReloading == true)
            {
                Reload();
                return;
            }

            if (enemy is IDamageble)
            {
                Shoot((IDamageble)enemy);
            }
            else
            {
                int targetIndex = Randomizer.GenerateNumber(0, enemy.UnitsAmount);
                Attack(enemy.Units[targetIndex]);
            }
        }

        public void GetDamage(int damage)
        {
            _health.Amount -= damage;

            if (_health.Amount == 0)
                GlobalKiller.Dead += Die;
            else if (_health.Amount < 0)
                throw new ArgumentOutOfRangeException(nameof(_health));
        }

        private void Shoot(IDamageble enemy)
        {
            int automaticShotsQueue = 5;
            bool canShoot = false;

            if (_weapon.IsAutomatic == true)
            {
                for (int i = 0; i < automaticShotsQueue; i++)
                    canShoot = _weapon.Shoot(enemy);
            }
            else
            {
                canShoot = _weapon.Shoot(enemy);
            }

            if (canShoot == false)
                _isReloading = true;
        }

        private void Reload()
        {
            int automaticReloadSize = 3;

            if (_weapon.IsAutomatic == true)
                _weapon.BulletsAmount += automaticReloadSize;
            else if (_isReloading == true)
                _weapon.BulletsAmount++;

            if (_weapon.BulletsAmount >= _weapon.BulletsCapacity)
                _isReloading = false;
        }

        private void Die() => _parentComposite.Remove(this);
    }
}