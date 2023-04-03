using ConsoleConflict.Units;

namespace ConsoleConflict.Weapons
{
    internal interface IAttackStrategy
    {
        public void Attack(IUnitComposite enemy);
    }
}
