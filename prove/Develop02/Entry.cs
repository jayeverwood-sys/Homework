using System;
using System.Globalization;
using System.Net;

public class Entry
{
    public string randomPrompt;
    public string response;
    public string date;

    public void Display()
    {
        Console.WriteLine($"Date: {date}  \n{randomPrompt} \n{response}");
    }

    public string toString()
    {
        return $"{date}  | {randomPrompt}  |  {response}";
    }
    public Entry(string dates, string randomPrompts, string responses)
    {
        date = dates;
        randomPrompt = randomPrompts;
        response = responses;
    }
}