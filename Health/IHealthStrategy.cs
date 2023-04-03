namespace ConsoleConflict.Units
{
    internal interface IHealthStrategy
    {
        public int MaxHealth { get; }

        public int Health { get; }

        public void TakeDamage(int damage);
    }
}
