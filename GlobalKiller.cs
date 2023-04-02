using System;

namespace ConsoleConflict
{
    internal static class GlobalKiller
    {
        public static event Action? Dead;
    }
}
