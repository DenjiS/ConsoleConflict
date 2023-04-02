namespace ConsoleConflict.Units
{
    internal interface IUnitFactory<T> where T : IUnitComposite
    {
        public T Get(string type);
    }
}