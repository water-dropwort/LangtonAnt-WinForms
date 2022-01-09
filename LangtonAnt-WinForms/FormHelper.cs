using System;
using System.Collections.Generic;
using System.Text;
using LangtonAnt_WinForms.Common;

namespace LangtonAnt_WinForms
{
    public static class FormHelper
    {
        /// <summary>
        /// Try parse nullable int
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryParseToNullableInt(string text, out int? value)
        {
            if (string.IsNullOrEmpty(text))
            {
                value = null;
                return true;
            }
            else if (int.TryParse(text, out int result))
            {
                value = result;
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }

        /// <summary>
        /// Try parse to int, and return Result class.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="name">used creating error message</param>
        /// <returns></returns>
        public static Result<int, string> TryParseToInt(string text, string name)
        {
            if (string.IsNullOrEmpty(text))
                return new Result<int, string>.Err(name + " is empty.");

            int output;
            if (false == int.TryParse(text, out output))
                return new Result<int, string>.Err($"Failed to parse {name}.");
            //else if (output < min || max < output)
            //    return new Result<int, string>.Err($"{name} is not between {min} to {max}.");
            else
                return new Result<int, string>.OK(output);
        }

        public static Result<int, string> InRange(int value, int min, int max, string name)
        {
            if (value < min || max < value)
                return new Result<int, string>.Err($"{name} is not between {min} to {max}.");
            else
                return new Result<int, string>.OK(value);
        }
    }
}
