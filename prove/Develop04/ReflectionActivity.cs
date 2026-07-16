using System;

public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string> {"Think of a time when you stood up for someone else.", "Think of a time when you did somethign really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."};
    private List<string> secondaryprompts = new List<string>{"Why was this experience meaningful to you","Have you ever done anything like this before?","How did you get started?","How did you feel when it was complete?","What made this time different than other times when you were not as successful?","What is your favorite thing about this experience?","What could you learn from this experience that applies to other situations?","What did you learn about yourself through this experience?","How can you keep this experience in mind in the future?","Do you have any regrets regarding this experience?"};
    public ReflectionActivity() : base("Reflection Activity", "This activity will allow you time to answer a prompt given to look back at the day that you've had.")
    {
        DisplayStartingMessage();
        countitDownLength();
    }
    public void HumbleReflect()
    {
        DisplaythePrompt(prompts);
        countitDown(7);
        
        bool done = false;

        DateTime start = DateTime.Now;
        while(done != true)
        {
            DisplaythePrompt(secondaryprompts);
            countitDown(7);
            if (start.AddSeconds(time) < DateTime.Now)
            {
                done = true;
            }
        }
        DisplayEndingMessage();
    }
}