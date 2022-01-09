using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;

namespace LangtonAnt_WinForms
{
    public static class Consts
    {
        /// <summary>
        /// Drawing cell size = PIXEL_SIZE * PIXEL_SIZE
        /// </summary>
        public static readonly int CELL_PIXEL_SIZE = 4;

        /// <summary>
        /// Char to behavior dictionary
        /// </summary>
        public static readonly IReadOnlyDictionary<char, Model.Behavior> BEHAVIOR_CHARS
            = new Dictionary<char, Model.Behavior>()
            {
                {'R', Model.Behavior.TurnRight },
                {'L', Model.Behavior.TurnLeft },
                {'U', Model.Behavior.UTurn },
                {'N', Model.Behavior.None }
            };

        /// <summary>
        /// String to nullable direction dictionary
        /// </summary>
        public static readonly IReadOnlyDictionary<string, Model.Direction?> DIRECTION_DICT
            = new Dictionary<string, Model.Direction?>()
            {
                { "Random", null },
                { Model.Direction.North.ToString(), Model.Direction.North },
                { Model.Direction.East.ToString(), Model.Direction.East },
                { Model.Direction.South.ToString(), Model.Direction.South },
                { Model.Direction.West.ToString(), Model.Direction.West },
            };

        /// <summary>
        /// Definition cell's colors
        /// </summary>
        public static readonly IReadOnlyList<Color> CELL_COLORS = Enumerable.Range(0, 30).Select(i => IntToColor(i)).ToArray();

        /// <summary>
        /// Brushes
        /// </summary>
        public static readonly IReadOnlyList<SolidBrush> CELL_COLOR_BRUSHES = CELL_COLORS.Select(c => new SolidBrush(c)).ToArray();

        /// <summary>
        /// Convert Int to Color
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static Color IntToColor(int x)
        {
            int r = PeriodicLinear(x, 8, 0);
            int g = PeriodicLinear(x, 150, 30);
            int b = PeriodicLinear(x, 200, 0);
            return Color.FromArgb(r,g,b);
        }

        private static int PeriodicLinear(int x, int a, int b)
        {
            return (a * x + b) % 255;
        }
    }
}
