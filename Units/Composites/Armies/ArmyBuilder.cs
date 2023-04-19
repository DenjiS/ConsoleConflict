using ConsoleConflict.Common.Units;
using ConsoleConflict.Units.Composites.Tanks;
using ConsoleConflict.Units.Soldiers;

using System.Collections.Generic;

namespace ConsoleConflict.Units.Composites.Armies
{
    internal class ArmyBuilder
    {
        private readonly int _squadSize = 10;
        private readonly string _armyName;

        private readonly SoldierFactory _soldiersFactory = new();
        private readonly TankFactory _tanksFactory = new();

        private readonly List<Unit> _units = new();

        public ArmyBuilder(string name)
        {
            _armyName = name;
        }

        public Army Build()
        {
            Army army = new(_armyName);

            foreach (Unit unit in _units)
            {
                army.Add(unit);
            }

            return army;
        }

        public ArmyBuilder AddSoldier(SoldierTypes type)
        {
            Unit soldier = _soldiersFactory.Get(type);
            _units.Add(soldier);

            return this;
        }

        public ArmyBuilder AddTank()
        {
            Tank tank = _tanksFactory.Get();
            _units.Add(tank);

            return this;
        }

        public ArmyBuilder AddTypedSquad(SoldierTypes type)
        {
            Squad squad = new(_squadSize);

            FillSquad(squad, type);
            _units.Add(squad);

            return this;
        }

        public ArmyBuilder AddTankSquad()
        {
            SoldierTypes supportUnitType = SoldierTypes.Trooper;

            Squad squad = new(_squadSize);
            Unit tank = _tanksFactory.Get();
            squad.Add(tank);

            FillSquad(squad, supportUnitType);
            _units.Add(squad);

            return this;
        }

        private void FillSquad(Squad squad, SoldierTypes type)
        {
            while (squad.UnitsSize < squad.Capacity)
            {
                Unit soldier = _soldiersFactory.Get(type);
                squad.Add(soldier);
            }
        }
    }
}
