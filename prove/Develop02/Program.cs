using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journael = new Journal();
        while (true)
        {
        Console.WriteLine("1. Write\n2.Display\n3.Save\n4.Load\n5.Quit");
        string input = Console.ReadLine();
        if (input == "1")
            {
                journael.write();
            }
        else if (input == "2")
            {
                journael.Display();
            }
        else if (input == "3")
            {
                journael.Save();
            }
        else if (input == "4")
            {
                journael.Load();
            }
        else if (input == "5")
            {
                break;
            }
        }
    }
}
