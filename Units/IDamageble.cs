namespace ConsoleConflict.Units
{
    internal interface IDamageble
    {
        public int MaxHealth { get; }

        public int Health { get; }

        public void GetDamage(int damage);
    }
}
