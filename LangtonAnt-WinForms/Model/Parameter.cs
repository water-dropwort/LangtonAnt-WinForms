using System;
using System.Collections.Generic;
using System.Text;
using LangtonAnt_WinForms.Common;

namespace LangtonAnt_WinForms.Model
{
    /// <summary>
    /// Parameter for LangtonAnt class
    /// </summary>
    public class Parameter
    {
        #region public properties
        /// <summary>
        /// Array or Behavior.
        /// This value corresponds to rule string such as RL and LLRR.
        /// </summary>
        public IReadOnlyList<Behavior> Rule { get; }

        /// <summary>
        /// Ant parameters
        /// </summary>
        public IReadOnlyList<AntParameter> AntParameters { get; }
        
        /// <summary>
        /// Rows number of cell's matrix
        /// </summary>
        public int Rows { get; }

        /// <summary>
        /// Column number of cell's matrix
        /// </summary>
        public int Columns { get; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="antParameters"></param>
        /// <param name="columns"></param>
        /// <param name="rows"></param>
        public Parameter(Behavior[] rule, AntParameter[] antParameters, int rows, int columns)
        {
            if (rule is null || rule.Length == 0)
                throw new ArgumentException("Error: rule is null or empty.");
            else if (antParameters is null || antParameters.Length == 0)
                throw new ArgumentException("Error: antParameters is null or empty.");
            else if (rows <= 0)
                throw new ArgumentException("Error: rows is less than or equal 0.");
            else if (columns <= 0)
                throw new ArgumentException("Error: columns is less than or equal 0.");

            Rule = rule;
            AntParameters = antParameters;
            Rows = rows;
            Columns = columns;
        }
    }

    /// <summary>
    /// Ant of Langton's Ant is created by this parameter.
    /// </summary>
    public class AntParameter
    {
        /// <summary>
        /// Initial index of matrix.
        /// If element of vector is null, the element is treated as a rundom number.
        /// ex.(i,j) = (null, 9) --> (random, 9)
        /// </summary>
        public Vector<int?> InitialIndex { get; }

        /// <summary>
        /// Initial direction.
        /// If this is null, initial direction is selected by random number.
        /// </summary>
        public Direction? InitialDirection { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="initial_i"></param>
        /// <param name="initial_j"></param>
        /// <param name="initialDirection"></param>
        public AntParameter(int? initial_i, int? initial_j, Direction? initialDirection)
        {
            InitialIndex = new Vector<int?>(initial_i, initial_j);
            InitialDirection = initialDirection;
        }
    }
}
