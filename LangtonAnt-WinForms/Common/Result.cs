using System;
using System.Collections.Generic;
using System.Text;

namespace LangtonAnt_WinForms.Common
{
    /// <summary>
    /// Result class inspired Elm
    /// </summary>
    /// <typeparam name="TOK"></typeparam>
    /// <typeparam name="TErr"></typeparam>
    public abstract class Result<TOK,TErr>
    {
        public abstract bool IsOK { get; }
        public bool IsErr => !IsOK;

        public OK ToOK() => this as OK;
        public Err ToErr() => this as Err;

        
        public sealed class OK : Result<TOK, TErr>
        {
            public override bool IsOK => true;

            public TOK Value { get; }

            public OK(TOK value)
            {
                Value = value;
            }
        }

        public sealed class Err : Result<TOK, TErr>
        {
            public override bool IsOK => false;

            public TErr Value { get; }

            public Err(TErr value)
            {
                Value = value;
            }
        }

        /// <summary>
        /// Apply function to value if this is OK class.
        /// </summary>
        /// <typeparam name="TOK2"></typeparam>
        /// <param name="f"></param>
        /// <returns></returns>
        public Result<TOK2,TErr> AndThen<TOK2>(Func<TOK,Result<TOK2, TErr>> f)
        {
            if (this.IsOK)
                return f(this.ToOK().Value);
            else
                return new Result<TOK2, TErr>.Err(this.ToErr().Value);
        }
    }
}
