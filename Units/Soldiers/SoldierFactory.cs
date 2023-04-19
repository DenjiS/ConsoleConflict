using ConsoleConflict.Common.Units;
using ConsoleConflict.Common.Weapons;
using System;
using System.Collections.Generic;

namespace ConsoleConflict.Units.Soldiers
{
    public enum SoldierTypes
    {
        Trooper,
        Scout,
        Mechanic
    }

    internal class SoldierFactory : DamagebleUnitFactory<Soldier, SoldierTypes>
    {
        private readonly Dictionary<SoldierTypes, SoldierConfig> _configurations = new();

        public SoldierFactory()
        {
            _configurations[SoldierTypes.Trooper] = new SoldierConfig(150, WeaponTypes.Riffle);
            _configurations[SoldierTypes.Scout] = new SoldierConfig(100, WeaponTypes.SniperRiffle);

            _configurations[SoldierTypes.Mechanic] = new SoldierConfig(50, WeaponTypes.Handgun);
        }

        public override Soldier Get(SoldierTypes specialization)
        {
            WeaponTypes weaponType = _configurations[specialization].Weapon;

            int health = _configurations[specialization].Health;
            IWeaponStrategy weapon = GunFactory.Get(weaponType);

            return new Soldier(health, weapon);
        }
    }
}
