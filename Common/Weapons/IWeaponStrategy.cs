using ConsoleConflict.Common.Units;

namespace ConsoleConflict.Common.Weapons
{
    internal interface IWeaponStrategy
    {
        public int Damage { get; }

        public void Attack(IUnitComposite enemy);
    }
}
