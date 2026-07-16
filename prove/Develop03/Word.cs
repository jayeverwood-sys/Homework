using System;

public class Word
{
    private string _word;
    private string _punctuation;
    private bool _isHidden;

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public HideWord()
    {
        string woord = "";

        for (i = 0; i < _word.Length; i++)
        {
            woord += "_";
        }
        _word = woord;
        _isHidden = true;
    }

    public GetWord()
    {
        return _word;
    }
    public GetHidden()
    {
        return _isHidden;
    }
}