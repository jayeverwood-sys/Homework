using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number?: ");
        int theNumber = int.Parse( Console.ReadLine());

        int guess = -1;

     while (guess != theNumber)
     {
        Console.Write("What is your guess?: ");
        guess = int.Parse(Console.ReadLine());

        if (theNumber > guess)
        {
            Console.WriteLine("Higher");
        }
        else if (theNumber < guess)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("YOU GOT IT!!!");   
        }

        }
    }
}