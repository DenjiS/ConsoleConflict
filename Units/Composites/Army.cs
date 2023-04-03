using System.Collections.Generic;

namespace ConsoleConflict.Units.Composites
{
    internal class Army : Composite
    {
        public Army(List<IUnitComposite> battlefield) : base(int.MaxValue, battlefield) { }
    }
}
