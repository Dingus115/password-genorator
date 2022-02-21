 using System;

namespace password_genorator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("What is your new password: ");
            string newPassword = Console.ReadLine();
            passwordChecker(newPassword);

        }

        private static int passwordChecker(string newPassword)
        {
            int result = 0;
            int totalNum = 0;
            int totalLetter = 0;

            foreach (char item in newPassword)
            {
                if (Char.IsDigit(item))
                {
                    totalNum++;
                }

                if (Char.IsLetter(item))
                {
                    totalLetter++;
                }
            }

            switch((totalLetter, totalNum))
            {
                case ( > 5, > 1):
                    result = 0;
            }

            return result;
        }
    }
}
