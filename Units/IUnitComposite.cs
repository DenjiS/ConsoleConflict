using System.Collections.Generic;

namespace ConsoleConflict.Units
{
    internal interface IUnitComposite
    {
        public IReadOnlyList<IUnitComposite> Units { get; }

        public int UnitsAmount => 1;

        public void Attack(IUnitComposite enemy);
    }
}
