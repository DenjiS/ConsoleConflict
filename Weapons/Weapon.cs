using ConsoleConflict.Units;

namespace ConsoleConflict.Weapons
{
    internal class Weapon : IWeapon
    {
        private readonly int _damage;
        private readonly int _magazineCapacity;
        private int _bulletsInMagazine;

        public Weapon(int damage, int capacity, bool isAutomatic)
        {
            _damage = damage;
            _magazineCapacity = capacity;
            _bulletsInMagazine = 0;

            IsAutomatic = isAutomatic;
        }

        public int BulletsCapacity => _magazineCapacity;

        public int BulletsAmount
        {
            get => _bulletsInMagazine;
            set
            {
                _bulletsInMagazine = value;

                if (_bulletsInMagazine > _magazineCapacity)
                    _bulletsInMagazine = _magazineCapacity;
                else if (_bulletsInMagazine < 0)
                    _bulletsInMagazine = 0;
            }
        }

        public bool IsAutomatic { get; }

        public bool Shoot(IDamageble enemy)
        {
            if (_bulletsInMagazine > 0)
            {
                enemy.GetDamage(_damage);
                return true;
            }

            return false;
        }
    }
}
