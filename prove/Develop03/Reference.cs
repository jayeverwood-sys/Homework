using System;


public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _startVerse;
    private int _endVerse;
    public Reference(string book, int chapter, int verse, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
    public DisplayReference()
    {
        if(_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse} ";
        }
        else if (_startVerse < _endVerse)
        {
           return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
        else
        {
           return "Invalid Statement.";
        }

    }
    
}