 using System;

namespace password_genorator
{
    class Program
    {
        static void Main(string[] args)                                         //Main method
        {
            
            Console.Write("What is your new password: ");                       //Ask User for new password
            string newPassword = Console.ReadLine();
            string answer = passwordChecker(newPassword);                          //pass to method-passwordChecker
            

            Console.WriteLine(answer);

        }

        private static string passwordChecker(string newPassword)                  //take in user input password
        {
            string result = null;
            int totalNum = 0;
            int totalLetter = 0;

            foreach (char character in newPassword)                                  //check specifications of password ie. letters/numbers
            {
                if (Char.IsDigit(character))
                {
                    totalNum++;
                }

                if (Char.IsLetter(character))
                {
                    totalLetter++;
                }
            }

            switch((totalLetter, totalNum))                                     //check total char to determine acceptance
            {
                case ( >=5, >= 1):
                    result = "Password has been accepted";
                    break;

                case ( < 5, >= 1):
                    result = "Not enough letters! Please try again.";
                    break;

                case ( >= 5, < 1):
                    result = "Not enough numbers! Please try again.";
                    break;

                case ( < 5, < 1):
                    result = "Not enough letters and numbers! Please try again";
                    break;
            }

            return result;                                                      //return string to main
        }
    }
}
