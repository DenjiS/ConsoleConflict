using ConsoleConflict.Common.Health;
using ConsoleConflict.Common.Weapons;

namespace ConsoleConflict.Common.Units
{
    internal abstract class DamagebleUnitFactory<T, TEnum> where T : IDamageble
    {
        protected readonly WeaponFactory GunFactory = new();

        public abstract T Get(TEnum specialization);
    }
}
