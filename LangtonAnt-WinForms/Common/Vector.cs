using System;
using System.Collections.Generic;
using System.Text;

namespace LangtonAnt_WinForms.Common
{
    public struct Vector<T>
    {
        public T E1 { get; }
        public T E2 { get; }

        public Vector(T e1, T e2)
        {
            E1 = e1;
            E2 = e2;
        }
    }
}
