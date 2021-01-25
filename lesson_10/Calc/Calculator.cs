using System;
using System.Linq;
using System.Text.RegularExpressions;
namespace lesson_10.Calc
{
    public class Calculator
    {
        public void greeting()
        {
            Console.WriteLine("Hi! My name is Terminal Calculator but you can call me T-Calc.");
            Console.WriteLine("I'll be helping you do some calculators today.");
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Nice to meet you " + name);
            startCalculator(name);
        }

        public static string startCalculator(string name)
        {
            Console.WriteLine(name + " - What type of calculation would you like to do? Add, subtract, multiply or devide?");
            string opperatorType = Console.ReadLine();
            checkOpperatorType(opperatorType, name);
            return Finish(name);
        }

        public static string checkOpperatorType(string opperatorType, string name)
        {
            // Different opperator words to detect

            string[] addWordsToDetect = new string[3];
            addWordsToDetect[0] = "Add";
            addWordsToDetect[1] = "add";
            addWordsToDetect[2] = "+";

            string[] subtractWordsToDetect = new string[3];
            subtractWordsToDetect[0] = "Subtract";
            subtractWordsToDetect[1] = "subtract";
            subtractWordsToDetect[2] = "-";

            string[] multiplyWordsToDetect = new string[3];
            multiplyWordsToDetect[0] = "Multiply";
            multiplyWordsToDetect[1] = "multiply";
            multiplyWordsToDetect[2] = "*";

            string[] devideWordsToDetect = new string[3];
            devideWordsToDetect[0] = "Devide";
            devideWordsToDetect[1] = "devide";
            devideWordsToDetect[2] = "/";

            // If the opperatorType user input is an exact match to any of these then we know the opperator type

            if (opperatorType == addWordsToDetect[0] || opperatorType == addWordsToDetect[1] || opperatorType == addWordsToDetect[2])
            {
                getNumbers("Add", name);
            }

            if (opperatorType == subtractWordsToDetect[0] || opperatorType == subtractWordsToDetect[1] || opperatorType == subtractWordsToDetect[2])
            {
                getNumbers("Subtract", name);
            }

            if (opperatorType == multiplyWordsToDetect[0] || opperatorType == multiplyWordsToDetect[1] || opperatorType == multiplyWordsToDetect[2])
            {
                getNumbers("Multiply", name);
            }

            if (opperatorType == devideWordsToDetect[0] || opperatorType == devideWordsToDetect[1] || opperatorType == devideWordsToDetect[2])
            {
                getNumbers("Devide", name);
            }

            // If not but the opperatorType user input contains any of the key words to detect then we guess

            if (opperatorType != addWordsToDetect[0] && opperatorType != addWordsToDetect[1] && opperatorType != addWordsToDetect[2] && opperatorType != subtractWordsToDetect[0] && opperatorType != subtractWordsToDetect[1] && opperatorType != subtractWordsToDetect[2] && opperatorType != multiplyWordsToDetect[0] && opperatorType != multiplyWordsToDetect[1] && opperatorType != multiplyWordsToDetect[2] && opperatorType != devideWordsToDetect[0] && opperatorType != devideWordsToDetect[1] && opperatorType != devideWordsToDetect[2])
            {
                // Check if the opperatorType contains the 'add' key words
                bool containsAdd = addWordsToDetect.Any(c => opperatorType.Contains(c));
                if (containsAdd == true)
                {
                    Console.WriteLine("I think you want to add, is this correct?");
                    checkYesOrNo("Add", name);
                }

                // Check if the opperatorType contains the 'subtract' key words
                bool containsSubtract = subtractWordsToDetect.Any(c => opperatorType.Contains(c));
                if (containsSubtract == true)
                {
                    Console.WriteLine("I think you want to subtract, is this correct?");
                    checkYesOrNo("Subtract", name);
                }

                // Check if the opperatorType contains the 'multiply' key words
                bool containsMultiply = multiplyWordsToDetect.Any(c => opperatorType.Contains(c));
                if (containsMultiply == true)
                {
                    Console.WriteLine("I think you want to multiply, is this correct?");
                    checkYesOrNo("Multiply", name);
                }

                // Check if the opperatorType contains the 'devide' key words
                bool containsDevide = devideWordsToDetect.Any(c => opperatorType.Contains(c));
                if (containsDevide == true)
                {
                    Console.WriteLine("I think you want to devide, is this correct?");
                    checkYesOrNo("Devide", name);
                }

                // If everything fails then we go to error handling

                if(containsAdd == false && containsSubtract == false && containsMultiply == false && containsDevide == false)
                {
                    opperatorTypeErrorHandling(name);
                }
            }
            return "";
        }

        public static string checkYesOrNo(string opperatorType, string name)
        {
            string userConfirm = Console.ReadLine();
            if (userConfirm == "Yes" || userConfirm == "yes" || userConfirm == "Y" || userConfirm == "y")
            {
                getNumbers(opperatorType, name);
            }
            else
            {
                Console.WriteLine("Darn it .. lets start again");
                startCalculator(name);
            }
            return "";
        }

        public static string getNumbers(string opperatorType, string name)
        {
            // Setting variables
            int firstNumberInt = 0;
            int secondNumberInt = 0;

            // First number
            Console.WriteLine("What's the starting number?");
            string firstNumber = Console.ReadLine();

            // First number error handling
            if (Regex.IsMatch(firstNumber, @"^\d+$"))
            {
                firstNumberInt = Int32.Parse(firstNumber);
            }
            else
            {
                Console.WriteLine("Please only use numeric characters 0 - 9");
                getNumbers(opperatorType, name);
            };

            // Second number
            Console.WriteLine("And the second number?");
            string secondNumber = Console.ReadLine();

            // Second number error handling
            if (Regex.IsMatch(secondNumber, @"^\d+$"))
            {
                secondNumberInt = Int32.Parse(secondNumber);
            }
            else
            {
                Console.WriteLine("Please only use numeric characters 0 - 9");
                getNumbers(opperatorType, name);
            }

            if (opperatorType == "Add")
            {
                add(firstNumberInt, secondNumberInt);
            }
            if (opperatorType == "Subtract")
            {
                subtract(firstNumberInt, secondNumberInt);
            }
            if (opperatorType == "Multiply")
            {
                multiply(firstNumberInt, secondNumberInt);
            }
            if (opperatorType == "Devide")
            {
                devide(firstNumberInt, secondNumberInt);
            }
            return Finish(name);
        }

            public static string opperatorTypeErrorHandling(string name)
        {
            Console.WriteLine("Sorry I didn't understand, please type 'add' if you would like to add, 'subtract' if you would like to subtract, 'multiply' if you would like to multiply or 'devide' if you would like to devide.");
            string opperatorType = Console.ReadLine();
            return checkOpperatorType(opperatorType, name);
        }

        public static int add(int x, int y)
        {
            int number = x + y;
            Console.WriteLine(x + " plus " + y + " is " + number);
            return number;
        }

        public static int subtract(int x, int y)
        {
            int number = x - y;
            Console.WriteLine(x + " minus " + y + " is " + number);
            return number;
        }

        public static int multiply(int x, int y)
        {
            int number = x * y;
            Console.WriteLine(x + " times " + y + " is " + number);
            return number;
        }

        public static int devide(int x, int y)
        {
            int number = x / y;
            Console.WriteLine(x + " devide by " + y + " is " + number);
            return number;
        }

        public static string Finish(string name)
        {
            Console.WriteLine("Run again?");
            string userConfirm = Console.ReadLine();
            if (userConfirm == "Yes" || userConfirm == "yes" || userConfirm == "Y" || userConfirm == "y")
            {
                return startCalculator(name);
            }
            else
            {
                Console.WriteLine("Thank you for using T-Calc, we hope you enjoyed using our service today - be sure to like, share and subscribe!");
            }

            return "";
        }
    }
}