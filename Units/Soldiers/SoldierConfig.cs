using ConsoleConflict.Common.Weapons;

namespace ConsoleConflict.Units.Soldiers
{
    internal readonly struct SoldierConfig
    {
        public SoldierConfig(int health, WeaponTypes weapon)
        {
            Health = health;
            Weapon = weapon;
        }

        public int Health { get; }

        public WeaponTypes Weapon { get; }
    }
}
