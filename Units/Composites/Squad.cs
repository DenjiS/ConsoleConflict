using System.Collections.Generic;

namespace ConsoleConflict.Units.Composites
{
    internal class Squad : Composite
    {
        public Squad(int size, List<IUnitComposite> parentComposite) : base(size, parentComposite) { }

    }
}
