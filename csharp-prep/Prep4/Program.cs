using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number(0 to quit): ");

            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            if(userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        int numAdd = 0;
        foreach (int number in numbers)
        {
            numAdd += number;

        }
        Console.WriteLine($" The sum is: {numAdd}");

        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max is: {max}");
    }
}