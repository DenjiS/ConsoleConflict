using ConsoleConflict.Units.Composites.Armies;
using ConsoleConflict.Units.Soldiers;
using System;
using System.Threading;

namespace ConsoleConflict
{
    internal class Program
    {
        public static void Main()
        {
            int sleepTime = 800;
            string leftName = "Left";
            string rightName = "Right";

            ArmyBuilder leftArmyBuilder = new(leftName);
            ArmyBuilder rightArmyBuilder = new(rightName);

            Army leftArmy = leftArmyBuilder
                .AddTankSquad()
                .AddTankSquad()
                .AddTypedSquad(SoldierTypes.Scout)
                .AddTypedSquad(SoldierTypes.Trooper)
                .Build();

            Army rightArmy = rightArmyBuilder
                .AddTankSquad()
                .AddTankSquad()
                .AddTypedSquad(SoldierTypes.Scout)
                .AddTypedSquad(SoldierTypes.Trooper)
                .Build();

            Renderer renderer = new(leftArmy, rightArmy);

            while (leftArmy.UnitsSize > 0 && rightArmy.UnitsSize > 0)
            {
              
                leftArmy.Attack(rightArmy);
                rightArmy.Attack(leftArmy);
                renderer.DrawArmies();

                Thread.Sleep(sleepTime);
                GlobalKiller.Dead?.Invoke();
            }

            Console.Clear();

            if (leftArmy.UnitsSize == 0)
            {
                Console.WriteLine("Right wins");
            }
            else if (rightArmy.UnitsSize == 0)
            {
                Console.WriteLine("Left wins");
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }
    }
}