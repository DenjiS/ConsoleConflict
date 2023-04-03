using System;
using System.Collections.Generic;

namespace ConsoleConflict.Weapons
{
    internal class WeaponFactory
    {
        private readonly Dictionary<string, WeaponConfig> _types = new();

        public WeaponFactory()
        {
            _types["handgun"]        = new WeaponConfig(10, 14);
            _types["riffle"]         = new WeaponConfig(50, 30, true);
            _types["sniper riffle"]  = new WeaponConfig(100, 5);

            _types["tank gun"]       = new WeaponConfig(150, 1);
        }

        public IAttackStrategy Get(string type)
        {
            if (_types.ContainsKey(type))
                return new WeaponAttack(_types[type].Damage, _types[type].BulletsCapacity, _types[type].IsAutomatic);
            else
                throw new ArgumentException();
        }
    }
}
