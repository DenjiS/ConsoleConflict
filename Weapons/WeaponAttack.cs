using ConsoleConflict.Units;
using ConsoleConflict.Units;

namespace ConsoleConflict.Weapons
{
    // Стоит ли выделить оружие и стратегию в отдельные классы, если они не используются отдельно друг от друга?
    internal class WeaponAttack : IAttackStrategy
    {
        private readonly int _damage;
        private readonly int _bulletsCapacity;
        private readonly bool _isAutomatic;
        private int _bulletsInMagazine;
        private bool _isReloading;

        public WeaponAttack(int damage, int capacity, bool isAutomatic)
        {
            _damage = damage;
            _bulletsCapacity = capacity;
            _bulletsInMagazine = 0;

            _isAutomatic = isAutomatic;
        }

        private int BulletsAmount
        {
            get => _bulletsInMagazine;
            set
            {
                _bulletsInMagazine = value;

                if (_bulletsInMagazine > _bulletsCapacity)
                    _bulletsInMagazine = _bulletsCapacity;
                else if (_bulletsInMagazine < 0)
                    _bulletsInMagazine = 0;
            }
        }

        public void Attack(IUnitComposite enemy)
        {
            if (_isReloading == true)
            {
                Reload();
                return;
            }

            IHealthStrategy damagebleEnemy = UnpackToDamagable(enemy);
            Shoot(damagebleEnemy);
        }

        private void Shoot(IHealthStrategy enemy)
        {
            int automaticShotsQueue = 5;
            bool canShoot = false;

            if (_isAutomatic == true)
            {
                for (int i = 0; i < automaticShotsQueue; i++)
                    canShoot = ShootSingle(enemy);
            }
            else
            {
                canShoot = ShootSingle(enemy);
            }

            if (canShoot == false)
                _isReloading = true;
        }

        private bool ShootSingle(IHealthStrategy enemy)
        {

            if (_bulletsInMagazine > 0)
            {
                enemy.TakeDamage(_damage);
                return true;
            }

            return false;
        }

        private void Reload()
        {
            int automaticReloadSize = 3;

            if (_isAutomatic == true)
                BulletsAmount += automaticReloadSize;
            else if (_isReloading == true)
                BulletsAmount++;

            if (BulletsAmount >= _bulletsCapacity)
                _isReloading = false;
        }

        private IHealthStrategy UnpackToDamagable(IUnitComposite composite)
        {
            if (composite is IHealthStrategy damageble)
            {
                return damageble;
            }
            else
            {
                int targetIndex = Randomizer.GenerateNumber(0, composite.UnitsAmount);
                return UnpackToDamagable(composite.Units[targetIndex]);
            }
        }
    }
}
