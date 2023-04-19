using ConsoleConflict.Common.Units;
using ConsoleConflict.Common.Weapons;
using ConsoleConflict.Units.Soldiers;

namespace ConsoleConflict.Units.Composites.Tanks
{
    public enum TankTypes
    {
        Default
    }

    internal class TankFactory : DamagebleUnitFactory<Tank, TankTypes>
    {
        private readonly SoldierFactory _soldiers = new();

        private readonly int defaultHealth = 300;
        private readonly int defaultCapacity = 3;
        private readonly int defaultMass = 5;

        public Tank Get() =>
            Get(TankTypes.Default);

        public override Tank Get(TankTypes specialization)
        {
            IWeaponStrategy weapon = GunFactory.Get(WeaponTypes.TankGun);
            Tank tank = new(defaultHealth, defaultCapacity, defaultMass, weapon);

            for (int i = 0; i < tank.Capacity; i++)
            {
                Soldier mechanic = _soldiers.Get(SoldierTypes.Mechanic);
                tank.Add(mechanic);
            }

            return tank;
        }
    }
}
