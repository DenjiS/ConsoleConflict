using System.Collections.Generic;

namespace ConsoleConflict.Units.Composites
{
    internal class Army : Composite
    {
        public Army() : base(int.MaxValue, new List<IUnitComposite>()) { }
    }
}
