using System;

public class Activity
{
    protected string _name;
    protected string _description;

    protected int time = -1;

    protected List<string> Prompts;

    private Random chance = new Random();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine(_description);
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Awesome job! Thank you for completing the {_name}");

    }
    public void countitDownLength()
    {
        time = -1;
        while (time == -1)
        {

            Console.WriteLine("How many seconds would you like to do this activity for?: ");
            time = int.Parse(Console.ReadLine());

            if (time == -1)
            {
                Console.WriteLine("Invalid input, try again.");
            }
            else if (time > -1)
                Console.WriteLine($"Awesome, we will do this activity for {time} ");
            else
            {
                Console.WriteLine("You Silly, try again! Also SpiderMan is peak content.");
            }
        }
    }
    public void countitDown(int time)
    {
        for (int i = 0; i < time; i++)
        {
            Console.WriteLine(time - 1);
            Thread.Sleep(1000);
        }
    }

    public void DisplaythePrompt(List<string> prompts)
    {
        Console.WriteLine($"\n {prompts[chance.Next(prompts.Count())]}");
    }


}