using System;
using System.Collections.Generic;
using System.Text;
using LangtonAnt_WinForms.Common;

namespace LangtonAnt_WinForms.Model
{
    /// <summary>
    /// Ant
    /// </summary>
    public class Ant
    {
        /// <summary>
        /// Index of cell's matrix.
        /// </summary>
        public Vector<int> Index { get; set; }

        public Direction Direction { get; set; }

        public Ant(Vector<int> index, Direction direction)
        {
            Index = index;
            Direction = direction;
        }
    }
}
