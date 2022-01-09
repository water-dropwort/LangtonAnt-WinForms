using System;
using System.Collections.Generic;
using System.Text;

namespace LangtonAnt_WinForms.Model
{
    /// <summary>
    /// Ant's direction
    /// </summary>
    public enum Direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3,
    }

    /// <summary>
    /// Ant's behavior
    /// </summary>
    public enum Behavior
    {
        TurnRight, // R
        TurnLeft, // L
        UTurn, // U
        None, // N
    }
}
