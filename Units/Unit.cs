using System.Collections.Generic;

namespace ConsoleConflict.Units
{
    internal abstract class Unit : IUnitComposite
    {
        protected readonly List<IUnitComposite> ParentComposite;
        protected readonly List<IUnitComposite> ChangableUnits = new();

        public Unit(List<IUnitComposite> parentComposite)
        {
            ParentComposite = parentComposite;

            ChangableUnits.Add(this);
        }

        public virtual int UnitsAmount => 1;

        public IReadOnlyList<IUnitComposite> Units => ChangableUnits;

        public abstract void Attack(IUnitComposite enemy);

        protected virtual void Die() => ParentComposite.Remove(this);
    }
}
