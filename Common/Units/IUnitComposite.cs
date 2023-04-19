using System.Collections.Generic;

namespace ConsoleConflict.Common.Units
{
    internal interface IUnitComposite
    {
        public IReadOnlyList<IUnitComposite> Units { get; }

        public int UnitsSize { get; }

        public void Attack(IUnitComposite enemy);

        public string GetInformation();
    }
}
