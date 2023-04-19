using System;
using System.Collections.Generic;

namespace ConsoleConflict.Common.Weapons
{
    public enum WeaponTypes
    {
        Handgun,
        Riffle,
        SniperRiffle,
        TankGun,
    }

    internal class WeaponFactory
    {
        private readonly Dictionary<WeaponTypes, WeaponConfig> _configurations = new();

        public WeaponFactory()
        {
            _configurations[WeaponTypes.Handgun] = new WeaponConfig(10, 14);
            _configurations[WeaponTypes.Riffle] = new WeaponConfig(20, 30, true);
            _configurations[WeaponTypes.SniperRiffle] = new WeaponConfig(65, 5);

            _configurations[WeaponTypes.TankGun] = new WeaponConfig(150, 1);
        }

        public IWeaponStrategy Get(WeaponTypes type)
        {
            if (_configurations.ContainsKey(type))
                return new WeaponStrategy(_configurations[type].Damage, _configurations[type].BulletsCapacity, _configurations[type].IsAutomatic);
            else
                throw new ArgumentException();
        }
    }
}
