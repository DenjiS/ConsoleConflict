using System.Collections.Generic;
using ConsoleConflict.Weapons;

namespace ConsoleConflict.Units.Soldiers
{
    internal class SoldierFactory
    {
        private readonly Dictionary<string, SoldierConfig> _types = new();
        private readonly WeaponFactory _weaponFactory = new();

        public SoldierFactory()
        {
            _types["trooper"] = new SoldierConfig(100, );
            _types["scout"] = new SoldierConfig();
        }

        public ISoldier Get(string specialization)
        {
            int health = _types[specialization].Health;
            IWeapon weapon = _types[specialization].Weapon;

            return new Soldier(health, weapon);
        }
    }
}
