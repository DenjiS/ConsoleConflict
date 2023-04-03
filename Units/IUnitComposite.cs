using ConsoleConflict.Weapons;
using System.Collections.Generic;

namespace ConsoleConflict.Units
{
    internal interface IUnitComposite : IAttackStrategy
    {
        public IReadOnlyList<IUnitComposite> Units { get; }

        public int UnitsAmount => 1;
    }
}
