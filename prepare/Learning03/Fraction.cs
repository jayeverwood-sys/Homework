using System;
using System.Dynamic;

public class Fraction
{
    private int Numerator;
    private int Denominator;

    public Fraction()
    {
        Numerator = 1;
        Denominator = 1;
    }

    public Fraction(int num)
    {
        Numerator = num;
        Denominator = 1;
    }
    public Fraction(int top, int bottom)
    {
        Numerator = top;
        Setbottom(bottom);
    }

    public void Setbottom(int bottom)
    {
        if (bottom != 0)
        {
            Denominator = bottom;
        }
        else
        {
            Denominator = 1;
        }
    }
    public int getBottom()
    {
        return Denominator;
    }

    public void setTop(int top)
    {
        Numerator = top;
    }

    public int getTop()
    {
        return Numerator;
    }

    public string GetFractionString()
    {
        string Totalnum = $"{Numerator}/{Denominator}";
        return Totalnum;
    }

    public double GetDecimalValue()
    {
        return (double)Numerator / (double)Denominator;
    }
}
