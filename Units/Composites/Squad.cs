using System.Collections.Generic;

namespace ConsoleConflict.Units.Composites
{
    internal class Squad : Composite
    {
        private readonly List<IUnitComposite> _parentList;

        public Squad(int size, List<IUnitComposite> units, List<IUnitComposite> parentList) : base(size, units)
        {
            _parentList = parentList;
        }

        protected override void Die() => _parentList.Remove(this);
    }
}
