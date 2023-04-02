using ConsoleConflict.Weapons;

namespace ConsoleConflict.Units.Soldiers
{
    internal readonly struct SoldierConfig
    {
        public SoldierConfig(int health, IWeapon weapon)
        {
            Health = health;
            Weapon = weapon;
        }

        public int Health { get; }

        public IWeapon Weapon { get; }
    }
}
