namespace ConsoleConflict.Common.Health
{
    internal interface IDamageble
    {
        public int MaxHealth { get; }

        public int Health { get; }

        public void TakeDamage(int damage);
    }
}
