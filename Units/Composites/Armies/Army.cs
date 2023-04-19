using ConsoleConflict.Common.Units;

namespace ConsoleConflict.Units.Composites.Armies
{
    internal class Army : Composite
    {
        public Army(string name) : base(int.MaxValue)
        {
            Name = name;
        }

        public string Name { get; }

        public override string GetInformation() =>
            Name;

        protected override void Die() { }
    }
}
