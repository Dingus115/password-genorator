 using System;

namespace password_genorator
{
    class Program
    {
        static void Main(string[] args)                                         //Main method
        {
            passwordCont(); // start check
        }


        private static void passwordCont()
        {
            Console.Write("What is your new password: ");                       //Ask User for new password
            string newPassword = Console.ReadLine();
            string answer = passwordValue(newPassword);                          //pass to method-passwordChecker
            
            while (answer != "Password accepted")
            {
                Console.WriteLine(answer);
                string suggestedPass = suggestedPassword();
                Console.WriteLine("Suggested password: {0}", suggestedPass);
                Console.Write("What is your new password: ");
                newPassword = Console.ReadLine();
                answer = passwordValue(newPassword);
            }

            Console.WriteLine(answer);
        }

        private static string passwordValue(string newPassword)                  //take in user input password
        {
            string result = null;
            int totalNum = 0;
            int totalLowerLetter = 0;
            int totalUpperLetter = 0;
            int totalLetter = 0;

            foreach (char character in newPassword)                                  //check specifications of password ie. letters/numbers
            {
                if (Char.IsDigit(character)) //check total num
                {
                    totalNum++;
                }
                if (Char.IsLower(character)) //check lower letters
                {
                    totalLowerLetter++;
                }
                if (Char.IsUpper(character)) //check upper letters
                {
                    totalUpperLetter++;
                }
                if (Char.IsLetter(character)) //check lower letters
                {
                    totalLetter++;
                }
            }

            result = passwordCheck(totalLetter, totalLowerLetter, totalUpperLetter, totalNum); //pass to check

            if(result == null)
            {
                result = "Password accepted";                                                  //set acceptance
            }

            return (result);                                                                   //return string to main
        }

        private static string passwordCheck(int totalLetter, int totalLower, int totalUpper, int totalNum)
        {
            string result = null;
            int passLegnth = totalLetter + totalLower + totalUpper + totalNum;

            if (passLegnth < 7)
            {
                result = "Password does not meat minimum character legnth. Please try again \n";
            }

            else
            {
                if (totalLetter < 5)
                {
                    result = "Not enough letters \n";
                }

                else
                {
                    if (totalUpper < 2)
                    {
                        result = "Not enough Upper case letters \n";
                    }

                    if (totalLower < 3)
                    {
                        result = result + "Not enough lower letters \n";
                    }
                }

                if (totalNum < 2)
                {
                    result = result + "Not enough numbers \n";
                }
            }
            return result;
        }

        private static string suggestedPassword()
        {
            string suggestedPassword;
            char[] suggestion = new char[9];
            Random letter = new Random();
            Random number = new Random();

            for (int i = 0; i < 7; i++)
            {
                suggestion[i] = (char)letter.Next('a', 'z');
            }

            for(int i = 7; i < 9; i++)
            {
                int num = number.Next(0, 9);
                suggestion[i] = Convert.ToChar(num);
            }

            suggestedPassword = string.Join("", suggestion);

            return Convert.ToString(suggestedPassword);
        }
    }
}
