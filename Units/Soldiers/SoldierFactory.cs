using System;
using System.Collections.Generic;
using ConsoleConflict.Weapons;

namespace ConsoleConflict.Units.Soldiers
{
    internal class SoldierFactory : IUnitFactory<Soldier>
    {
        private readonly Dictionary<string, SoldierConfig> _types = new();
        private readonly WeaponFactory _weaponFactory = new();

        public SoldierFactory()
        {
            _types["trooper"] = new SoldierConfig(100, _weaponFactory.Get("автомат"));
            _types["scout"] = new SoldierConfig();
        }

        public Soldier Get(string specialization, List<IUnitComposite> parentList)
        {
            int health = _types[specialization].Health;
            IAttackStrategy weapon = _types[specialization].Weapon;

            if (_types.ContainsKey(specialization))
                return new Soldier(health, weapon, parentList);
            else
                throw new ArgumentException();
        }
    }
}
