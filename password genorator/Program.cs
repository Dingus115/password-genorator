using System;
using System.Linq;

namespace password_genorator
{
    class Program
    {

        public static char[] specialChar = { '!', '@', '#', '$', '%', '^', '&', '*' };
        static void Main(string[] args)                                         //Main method
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
            int result = 0;
            string accepted = null;
            int totalNum = 0;
            int totalLowerLetter = 0;
            int totalUpperLetter = 0;
            int totalLetter = 0;
            int totalSpecial = 0;

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
                if (Char.IsLetter(character)) //check letters
                {
                    totalLetter++;
                }

                //if(character == '!' || '@' || '#' || '$' || '%' || '^' || '&' || '*')
                for (int i = 0; i < specialChar.Length; i++) //check for specific special char           lowkey this sucks
                {
                    if(character == specialChar[i])
                    {
                        totalSpecial++;
                    }
                }
            }

            result = passwordCheck(totalLetter, totalLowerLetter, totalUpperLetter, totalNum, totalSpecial); //pass to check

            if(result == 0)
            {
                accepted = "Password accepted";                                                  //set acceptance
            }
            return (accepted);                                                                   //return string to main
        }

        private static int passwordCheck(int totalLetter, int totalLower, int totalUpper, int totalNum, int totalSpecial)
        {
            int passLegnth = totalLetter + totalNum + totalSpecial;
            int result = 0;
            if (passLegnth < 9)
            {
                Console.WriteLine("Password does not meat minimum reuqirements. \nPassword must include:");
                result = 1;
            }
            if (totalLetter < 5)
            {
                Console.WriteLine("Password must have minimum 5 letters");
                result = 1;
            }
            if (totalUpper < 2)
            {
                Console.WriteLine("Password must have at least 2 Upper case Characters");
                result = 1;
            }
            if (totalLower < 3)
            {
                Console.WriteLine("Password must have at least 3 Lower case Characters");
                result = 1;
            }
            if (totalNum < 3)
            {
                Console.WriteLine("Password must have at least 3 Numbers");
                result = 1;
            }
            if(totalSpecial < 1)
            {
               Console.WriteLine("Password must have at least 1 special character \n (ie: !, @, #, $, %, ^, &, *)");
                result = 1;
            }
            return result;
        }

        private static string suggestedPassword()
        {
            string suggestedPassword;
            char[] suggestion = new char[10];
            Random rnd = new Random();

            for (int i = 0; i < 7; i++)                     //creates 7 random letters
            {
                suggestion[i] = (char)rnd.Next('a', 'z');
            }

            for(int i = 6; i < 9; i++)                      //adds 3 random numbers to the end of the suggested password
            {
                //int num = number.Next(9);                     Converts num into a special character rather than a number
                //suggestion[i] = Convert.ToChar(num);

                int num = rnd.Next(9);
                suggestion[i] = Convert.ToChar(Convert.ToString(num));
            }

            int special = rnd.Next(7);                      //picks a random special character to add
            suggestion[9] = specialChar[special];
            suggestedPassword = string.Join("", suggestion);
            suggestedPassword = new string(suggestedPassword.ToCharArray().OrderBy(s => (rnd.Next(2) % 2) == 0).ToArray()); //randomizes the order of characters in the password
            return suggestedPassword;
        }
    }
}
