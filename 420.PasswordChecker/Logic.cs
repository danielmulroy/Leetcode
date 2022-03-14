using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420.PasswordChecker
{
    internal static class Logic
    {
        public static int StrongPasswordChecker(string password)
        {
            var length = password.Length;
            if (length < 5) return 6 - length;
            if (length > 20) return DoLongPass(password);
            var upper = 0;
            var lower = 0;
            var number = 0;
            var prev = '/';
            var prevPrev = '+';
            var cons = new Dictionary<int, int>(); // <startIndex, length>
            var consecutive = false;
            var startIndex = 0;

            for (var i = 0; i < password.Length; i++)
            {
                var c = password[i];

                if (!consecutive && prev == c && prevPrev == c)
                {
                    startIndex = i - 2;
                    consecutive = true;
                }
                else if (consecutive && prevPrev == prev && prev != c)
                {
                    cons.Add(startIndex, i);
                    consecutive = false;
                }

                if (char.IsLower(c))
                    lower = 1;
                else if (char.IsUpper(c))
                    upper = 1;
                else if (char.IsDigit(c))
                    number = 1;

                prevPrev = prev;
                prev = c;
            }

            if (consecutive)
            {
                if (startIndex == 0 && length == 5) return 2;
                cons.Add(startIndex, password.Length);
            }

            if (cons.Count == 0)
            {
                if (length == 5) return 1;
                return 3 - upper - lower - number;
            }

            var sum = 0;
            foreach (var con in cons)
            {
                sum += (con.Value - con.Key) / 3;
            }

            return sum;
        }
    }
}
