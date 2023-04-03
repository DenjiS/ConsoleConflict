using ConsoleConflict.Weapons;

namespace ConsoleConflict.Units.Soldiers
{
    internal readonly struct SoldierConfig
    {
        public SoldierConfig(int health, IAttackStrategy weapon)
        {
            Health = health;
            Weapon = weapon;
        }

        public int Health { get; }

        public IAttackStrategy Weapon { get; }
    }
}
