using System;
namespace FunWithExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter two numbers: ");

            var num1 = getSafeInt();
            var num2 = getSafeInt();
            var quotient = divideInts(num1, num2);
            Console.WriteLine($"The result of the calculation is {quotient}.");

            int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
            int length = numbers.Length;

            var notCorrectSum = sumOfNumbers(numbers, 2);
            Console.WriteLine($"Exception thrown.");
            var sum = sumOfNumbers(numbers, length);
            Console.WriteLine($"The sum of the array is: {sum}");

        }
        public static int divideInts(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Please do not try to divide by Zero. You've broken the math!");
                return 0;
            }

        }
        public static int getSafeInt()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("You did not enter a number. Try again.");
                return getSafeInt();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("How did you enter a null? That took some skills.");
                return getSafeInt();
            }
            catch (OverflowException)
            {
                Console.WriteLine($"That is too big a of number, try again with a number between {int.MinValue} and {int.MaxValue}");
                return getSafeInt();
            }
        }
        public static int sumOfNumbers(int[] numbers, int length)
        {
            try
            {
                if (length == numbers.Length)
                {
                    int total = 0;

                    foreach (var num in numbers)
                    {
                        total += num;
                    }
                    return total;
                } else {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The lengths did not match");
                return 0;
            }

        }
    }
}