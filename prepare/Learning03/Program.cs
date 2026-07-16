using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
       Fraction frac = new Fraction(); 
       Console.WriteLine(frac.GetFractionString());
       Console.WriteLine(frac.GetDecimalValue());

       Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

       Random random = new Random();
       Fraction frac2 = new Fraction();
       for(int i = 0; i < 20; i++)
        {
            int topVal = random.Next();
            int bottomVal = random.Next();
            frac2.setTop(topVal);
            frac2.Setbottom(bottomVal);
            Console.Write($"Fraction {i+1}: ");
            Console.Write($"string: {frac2.GetFractionString()}");
            Console.WriteLine($" Number: {frac2.GetDecimalValue()}");
        }
    }
}