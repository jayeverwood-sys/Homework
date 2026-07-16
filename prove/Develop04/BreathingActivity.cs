using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by doing a technique known as Box breathing where you'll breathe in for an amount of time that you decide on.")
    {

    }
    public void GuideBreathing()
    {

        bool done = false;
        DisplayStartingMessage();

        countitDownLength();

        DateTime start = DateTime.Now;
        while (done != true)
        {
            Console.WriteLine("Breathe in...");
            countitDown(5);
            Console.WriteLine("Now Breathe Out...");
            countitDown(7);
            if (start.AddSeconds(time) < DateTime.Now)
            {
                done = true;
            }
        }
        DisplayEndingMessage();
    }

}