 using System;

namespace password_genorator
{
    class Program
    {
        static void Main(string[] args)                                         //Main method
        {
            passwordCont();
        }


        private static void passwordCont()
        {
            Console.Write("What is your new password: ");                       //Ask User for new password
            string newPassword = Console.ReadLine();
            string answer = passwordChecker(newPassword);                          //pass to method-passwordChecker
            Console.WriteLine(answer);
        }

        private static string passwordChecker(string newPassword)                  //take in user input password
        {
            string result = null;
            int tryAgain = 0;
            int totalNum = 0;
            int totalLowerLetter = 0;
            int totalUpperLetter = 0;
            int totalLetter = 0;


            foreach (char character in newPassword)                                  //check specifications of password ie. letters/numbers
            {
                if (Char.IsDigit(character))
                {
                    totalNum++;
                }

                if (Char.IsLower(character))
                {
                    totalLowerLetter++;
                }

                if (Char.IsUpper(character))
                {
                    totalUpperLetter++;
                }

                if (Char.IsLetter(character))
                {
                    totalLetter++;
                }
            }

            if (newPassword.Length < 7)
            {
                result = "Password does not meat minimum character legnth. Please try again";
                tryAgain = 1;
            }

            else
            {
                if (totalLetter < 5)
                {
                    result = "Not enough letters \n";
                    tryAgain = 1;
                }

                else
                {
                    if (totalUpperLetter < 2)
                    {
                        result = "Not enough Upper case letters \n";
                        tryAgain = 1;
                    }

                    if (totalLowerLetter < 3)
                    {
                        result = result + "Not enough lower letters \n";
                        tryAgain = 1;
                    }
                }

                if (totalNum < 2)
                {
                    result = result + "Not enough numbers \n";
                    tryAgain = 1;
                }
            }


            return (result);                                                      //return string to main
        }
    }
}
