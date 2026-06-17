using System;

public class ListingActivity : Activity
{
    private List<string> prompts = new List<string> { "Who are the people that you appreciate?", "What are your personal strengths?", "Who are the people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?", "How was the last time you spent with friends or outside?" };
    public ListingActivity() : base("Listing Activity", "This activity will help you to reflect upon the good things in your life by being able to list out all the good you can remember.")
    {
        DisplayStartingMessage();
        countitDownLength();
    }
    public void ManyItems()
    {
        int countit = 0;
        bool done = false;

        DateTime start = DateTime.Now;

        DisplaythePrompt(prompts);
        
        countitDown(7);
        while (done != true)
        {
            Console.ReadLine();
            countit++;
            
            if (start.AddSeconds(time) < DateTime.Now)
            {
                done = true;
            }
        }
        Console.WriteLine($"Congrats! You listed out {countit} items!");
        DisplayEndingMessage();
    }
}
