using ConsoleConflict.Weapons;
using System.Collections.Generic;

namespace ConsoleConflict.Units.Composites.Tanks
{
    internal class Tank : Composite, IDamageble
    {
        private int _mass;
        private readonly List<IUnitComposite> _parentList;
        private Health _health;

        public Tank(int health, int capacity, int mass, IWeapon weapon, List<IUnitComposite> units, List<IUnitComposite> parentList) : base(capacity, units)
        {
            _mass = mass;
            _health = new Health(health);
            _parentList = parentList;
        }

        public int MaxHealth => _health.Max;

        public int Health => _health.Amount;

        public override int UnitsAmount => base.UnitsAmount + _mass;

        public void GetDamage(int damage)
        {
            _health.Amount -= damage;

            if (_health.Amount == 0)
                GlobalKiller.Dead += Die;
        }

        protected override void Die()
        {
            _parentList.AddRange(Units);
            _parentList.Remove(this);
        }
    }
}
