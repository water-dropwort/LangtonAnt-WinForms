using System;
using System.Collections.Generic;
using System.Text;

namespace LangtonAnt_WinForms.Common
{
    public interface IReadOnlyMatrix<T>
    {
        public T this[int i,int j] { get; }
        public T this[Vector<int> vindex] { get; }
    }

    public class Matrix<T> : IReadOnlyMatrix<T>
    {
        public T this[int i, int j]
        {
            get => mArray[i, j];
            set => mArray[i, j] = value;
        }

        public T this[Vector<int> vindex]
        {
            get => mArray[vindex.E1, vindex.E2];
            set => mArray[vindex.E1, vindex.E2] = value;
        }

        public int Rows { get; }

        public int Columns { get; }

        private readonly T[,] mArray;

        public Matrix(int rows, int columns, T[,] array)
        {
            mArray = array;
            Rows = rows;
            Columns = columns;
        }
    }
}
