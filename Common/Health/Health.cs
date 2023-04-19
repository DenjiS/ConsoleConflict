namespace ConsoleConflict.Common.Health
{
    internal class Health
    {
        private readonly int _maxAmount;
        private int _amount;

        public Health(int maxAmount)
        {
            _maxAmount = maxAmount;
            _amount = _maxAmount;
        }

        public int Max => _maxAmount;

        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;

                if (_amount > _maxAmount)
                    _amount = _maxAmount;
                else if (_amount < 0)
                    _amount = 0;
            }
        }
    }
}
