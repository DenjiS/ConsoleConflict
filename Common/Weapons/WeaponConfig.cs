namespace ConsoleConflict.Common.Weapons
{
    internal readonly struct WeaponConfig
    {
        public WeaponConfig(int damage, int capacity, bool isAutomatic = false)
        {
            Damage = damage;
            BulletsCapacity = capacity;
            IsAutomatic = isAutomatic;
        }

        public int Damage { get; }

        public int BulletsCapacity { get; }

        public bool IsAutomatic { get; }
    }
}
