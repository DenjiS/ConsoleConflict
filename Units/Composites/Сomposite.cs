using System;
using System.Collections.Generic;

namespace ConsoleConflict.Units.Composites
{
    internal abstract class Composite : IUnitComposite
    {
        private List<IUnitComposite> _units = new();

        public Composite(int capacity, List<IUnitComposite> units)
        {
            _units = units;
            Capacity = capacity;
        }

        public IReadOnlyList<IUnitComposite> Units => _units;

        public int Capacity { get; }

        public virtual int UnitsAmount
        {
            get
            {
                int amount = 0;

                foreach (var unit in Units)
                    amount += unit.UnitsAmount;

                return amount;
            }
        }

        public void Add(IUnitComposite unit)
        {
            if (UnitsAmount + unit.UnitsAmount > Capacity)
                throw new ArgumentException(nameof(unit));
            else
                _units.Add(unit);
        }

        public void Remove(IUnitComposite unit)
        {
            _units.Remove(unit);

            if (_units.Count == 0)
                GlobalKiller.Dead += Die;
        }

        public virtual void Attack(IUnitComposite enemy)
        {
            foreach (var unit in _units)
                unit.Attack(enemy);
        }

        protected abstract void Die();
    }
}
