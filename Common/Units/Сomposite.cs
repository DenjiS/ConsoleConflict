using System;

namespace ConsoleConflict.Common.Units
{
    internal abstract class Composite : Unit
    {
        public Composite(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity { get; }

        public override int UnitsSize
        {
            get
            {
                int amount = 0;

                foreach (var unit in Units)
                {
                    amount += unit.UnitsSize;
                }

                return amount;
            }
        }

        public void Add(Unit unit)
        {
            if (CheckOverweight(unit))
            {
                throw new ArgumentException(unit.ToString());
            }
            else if (ChildUnits.Contains(unit) == false)
            {
                ChildUnits.Add(unit);
                unit.SetParent(this);
            }
        }

        public void Remove(IUnitComposite unit)
        {
            ChildUnits.Remove(unit);

            if (Units.Count == 0)
            {
                GlobalKiller.Dead += Die;
            }
        }

        public override void Attack(IUnitComposite enemy)
        {
            foreach (var unit in Units)
            {
                unit.Attack(enemy);
            }
        }

        public override string GetInformation() =>
            base.GetInformation() + $" units {Units.Count} / {Capacity} ||";

        protected virtual bool CheckOverweight(IUnitComposite unit) =>
            UnitsSize + unit.UnitsSize > Capacity;
    }
}
