using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LangtonAnt_WinForms.Common;

namespace LangtonAnt_WinForms.Model
{
    public static class ModelHelper
    {
        /// <summary>
        /// Create ants from parameter.
        /// </summary>
        public static Ant[] CreateAnts(Parameter parameter)
        {
            return parameter.AntParameters.Select(ap => CreateAnt(ap, parameter.Columns, parameter.Rows)).ToArray();
        }

        /// <summary>
        /// Create ant from ant parameter, matrix size.
        /// </summary>
        public static Ant CreateAnt(AntParameter antParameter, int rows, int columns)
        {
            var rand = new Random();
            int max_i = rows - 1; // For examle, if rows is 100, i(index) is between 0 to 99.
            int max_j = columns - 1;

            var posV = new Vector<int>(Wrap(antParameter.InitialIndex.E1 ?? rand.Next(0, max_i), 0, max_i)
                                    , Wrap(antParameter.InitialIndex.E2 ?? rand.Next(0, max_j), 0, max_j));

            var direction = antParameter.InitialDirection ?? (Direction)rand.Next(0, Enum.GetValues(typeof(Direction)).Length - 1);
            return new Ant(posV, direction);
        }

        /// <summary>
        /// Change direction
        /// </summary>
        public static Direction ChangeDirection(Behavior beh, Direction direction)
        {
            int iDirection = (int)direction;
            int max = Enum.GetValues(typeof(Direction)).Length - 1;

            int iNextDirection = beh switch
            {
                Behavior.TurnRight => Wrap(iDirection + 1, 0, max),
                Behavior.TurnLeft => Wrap(iDirection - 1, 0, max),
                Behavior.UTurn => Wrap(iDirection + 2, 0, max),
                Behavior.None => iDirection,
                _ => throw new InvalidOperationException(),
            };

            return (Direction)iNextDirection;
        }

        /// <summary>
        /// Move ant in the current direction.
        /// </summary>
        public static void MoveAnt(Ant ant, int rows, int columns)
        {
            int max_i = rows - 1;
            int max_j = columns - 1;

            var delta = Delta(ant.Direction);
            int new_i = Wrap(ant.Index.E1 + delta.E1, 0, max_i);
            int new_j = Wrap(ant.Index.E2 + delta.E2, 0, max_j);
            ant.Index = new Vector<int>(new_i, new_j);
        }

        /// <summary>
        /// Direction to amount of change in index.
        /// </summary>
        public static Vector<int> Delta(Direction direction)
        {
            return direction switch
            {
                Direction.North => new Vector<int>(-1, 0),
                Direction.East => new Vector<int>(0, 1),
                Direction.South => new Vector<int>(1, 0),
                Direction.West => new Vector<int>(0, -1),
                _ => throw new InvalidOperationException(),
            };
        }

        /// <summary>
        /// Wrap integer
        /// </summary>
        public static int Wrap(int value, int min, int max)
        {
            if (min <= value && value <= max)
                return value;

            // [min,max] ==> [0,max-min]
            int max_ = max - min;
            int value_ = value - min;
            int len = max_ + 1;

            if (max_ < value_)
                return value_ % len + min;
            else
                return value_ + len * (int)Math.Ceiling((double)Math.Abs(value_) / len) + min;
        }

        /// <summary>
        /// get array element
        /// </summary>
        public static T WrapGet<T>(this IReadOnlyList<T> ts, int idx)
        {
            return ts[Wrap(idx, 0, ts.Count - 1)];
        }
    }
}
