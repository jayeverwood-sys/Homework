using System;
using System.IO;

public class Journal
{
    List<Entry> Entries = new List<Entry>();

    public void Save()
    {
        Console.WriteLine($"What's the name of your file?: ");
        string path = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(path))
        {
            foreach (Entry entri in Entries)
            {
                outputFile.WriteLine(entri.toString());
            }
        }
    }
    public void Load()
    {
        Console.WriteLine($"What's the name of your file?: ");
        string path = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(path);

        Entries.Clear();
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            Entry entrey = new Entry(parts[0], parts[1], parts[2]);
            Entries.Add(entrey);
        }
    }
    public void Display()
    {
        foreach (Entry entri in Entries)
        {
            entri.Display();
        }

    }
    public string ranPrompts()
    {
        var list = new List<string> { "What was your favorite part of the day?", "What was something that made your day not the greatest? :(", "How did you see the Lord in your day today?", "What was your favorite meal from today?", "Who are you grateful for today?", "What was one thing that you learned today?" };
        var random = new Random();
        int index = random.Next(list.Count);
        string randomItem = list[index];

        return randomItem;
    }
    public void write()
    {
        string ranprompt = ranPrompts();
        Console.WriteLine(ranprompt);
        string newEntry = Console.ReadLine();
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        Entry Entruyes = new Entry(dateText, ranprompt, newEntry);
        Entries.Add(Entruyes);
    }
}