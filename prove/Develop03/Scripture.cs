using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    public Scripture(Reference reference, string aword)
    {
     _reference = reference;
        foreach(string w in aword.Split(" "))
        {
            Word word = new Word(w);
            _words.Add(word);
        }
    }
    public DisplayScripture()
    {
        string text = "";
        foreach(Word word in _words)
        {
            text += word.GetWord() + " ";
        }
        Console.WriteLine($"{_reference} ");

    }
    public void HideRandomWords()
    {
        
    }
    public List<Word> TrackRemainWords()
    {
        
    }

   
}