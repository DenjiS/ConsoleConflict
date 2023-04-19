using ConsoleConflict.Common.Units;
using ConsoleConflict.Units.Composites.Armies;
using System;

namespace ConsoleConflict
{
    internal class Renderer
    {
        private readonly Army _leftArmy;
        private readonly Army _rightArmy;

        public Renderer(Army leftArmy, Army rightArmy)
        {
            _leftArmy = leftArmy;
            _rightArmy = rightArmy;
        }

        public void DrawArmies()
        {
            int leftIndent = 1;
            int rightIndent = 60;

            int startRow = 1;
            int leftRow = startRow;
            int rightRow = startRow;

            Console.Clear();
            DrawUnits(_leftArmy, leftIndent, ref leftRow);
            DrawUnits(_rightArmy, rightIndent, ref rightRow);
        }

        private void DrawUnits(IUnitComposite composite, int indent, ref int row, int depth = 0)
        {
            string text = composite.GetInformation();

            for (int i = 0; i < depth; i++)
                text = "--" + text;

            DrawCell(indent, ++row, text);

            if (composite is Composite)
            {
                depth++;

                foreach (IUnitComposite unit in composite.Units)
                    DrawUnits(unit, indent, ref row, depth);
            }
        }

        private static void DrawCell(int indent, int row, string text)
        {
            Console.SetCursorPosition(indent, row);
            Console.Write(text);
        }
    }
}
