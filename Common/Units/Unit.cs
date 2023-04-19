using System.Collections.Generic;

namespace ConsoleConflict.Common.Units
{
    internal abstract class Unit : IUnitComposite
    {
        protected readonly List<IUnitComposite> ChildUnits = new();
        protected Composite? ParentComposite;

        public virtual int UnitsSize => 1;

        public IReadOnlyList<IUnitComposite> Units => ChildUnits;

        public void SetParent(Composite parentComposite) =>
            ParentComposite = parentComposite;

        public abstract void Attack(IUnitComposite enemy);

        public virtual string GetInformation() =>
            $"|| {this.GetType().Name} ||";

        protected virtual void Die()
        {
            ParentComposite?.Remove(this);
        }
    }
}
