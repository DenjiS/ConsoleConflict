using System;
using System.Collections.Generic;

namespace ConsoleConflict.Units.Composites
{
    internal abstract class Composite : Unit
    {
        public Composite(int capacity, List<IUnitComposite> parentComposite) : base(parentComposite)
        {
            Capacity = capacity;
        }

        public int Capacity { get; }

        public override int UnitsAmount
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
                ChangableUnits.Add(unit);
        }

        public void Remove(IUnitComposite unit)
        {
            ChangableUnits.Remove(unit);

            if (Units.Count == 0)
                GlobalKiller.Dead += Die;
        }

        public override void Attack(IUnitComposite enemy)
        {
            foreach (var unit in Units)
                unit.Attack(enemy);
        }
    }
}
