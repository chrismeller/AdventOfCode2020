using System;
using System.Linq;

namespace AdventOfCode.Day2
{
    public class Problem2
    {
        public static int Solve()
        {
            var passwords = Problem1.GetPasswords();

            var compliant = passwords.Count(IsCompliant);

            return compliant;
        }

        public static bool IsCompliant(Problem1.PasswordPolicy password)
        {
            var letters = password.Password.ToCharArray().Select(x => Convert.ToString(x)).ToList();

            var letter1 = letters[password.Min - 1];
            var letter2 = letters[password.Max - 1];

            if (letter1 == password.Letter && letter2 != password.Letter)
            {
                return true;
            }
            
            if (letter1 != password.Letter && letter2 == password.Letter)
            {
                return true;
            }

            return false;
        }
    }
}