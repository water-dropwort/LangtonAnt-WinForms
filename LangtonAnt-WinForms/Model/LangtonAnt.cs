using System;
using System.Collections.Generic;
using System.Text;
using LangtonAnt_WinForms.Common;

namespace LangtonAnt_WinForms.Model
{
    /// <summary>
    /// Langton's ant
    /// </summary>
    public class LangtonAnt
    {
        #region public-property
        /// <summary>
        /// Matrix of cells value.
        /// </summary>
        public IReadOnlyMatrix<int> Cells => mCells;

        /// <summary>
        /// Parameter
        /// </summary>
        public Parameter Parameter { get; }
        #endregion

        #region private-field
        private readonly Matrix<int> mCells;
        private readonly Ant[] mAnts;
        #endregion

        #region public-function
        /// <summary>
        /// Consructor
        /// </summary>
        public LangtonAnt(Parameter parameter)
        {
            Parameter = parameter;
            mCells = new Matrix<int>(Parameter.Rows, Parameter.Columns, new int[Parameter.Rows, Parameter.Columns]);
            mAnts = ModelHelper.CreateAnts(Parameter);
        }

        /// <summary>
        /// Update cell's status and move ants
        /// </summary>
        /// <returns>Array of index that updated cells</returns>
        public Vector<int>[] Update()
        {
            var list = new List<Vector<int>>();
            foreach (Ant ant in mAnts)
            {
                // Change ant's direction
                ant.Direction = ModelHelper.ChangeDirection(Parameter.Rule.WrapGet(mCells[ant.Index]), ant.Direction);
                // Update cell's value
                mCells[ant.Index] = ModelHelper.Wrap(mCells[ant.Index] + 1, 0, Parameter.Rule.Count - 1);
                list.Add(ant.Index);
                // Move ant
                ModelHelper.MoveAnt(ant, Parameter.Rows, Parameter.Columns);
            }
            return list.ToArray();
        }
        #endregion
    }
}
