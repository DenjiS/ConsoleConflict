using ConsoleConflict.Units;

namespace ConsoleConflict.Weapons
{
    internal interface IWeapon
    {
        public int BulletsCapacity { get; }

        public int BulletsAmount { get; set; }

        public bool IsAutomatic { get; }

        public bool Shoot(IDamageble enemy);
    }
}
