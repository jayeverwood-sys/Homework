using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment as1 = new Assignment("Jay Davis", "Calculus");
        Console.WriteLine(as1.GetSummary());

        MathAssignments as2 = new MathAssignments("Laelle Davis", "Algebra", "2.4","66-70");
        Console.WriteLine(as2.GetSummary());
        Console.WriteLine(as2.GetHomeworkList());

        WritingAssignment as3 = new WritingAssignment("Logan Davis", "Creative Writing", "The World of Slay the Spire");
        Console.WriteLine(as3.GetSummary());
        Console.WriteLine(as3.GetWritingInfo());
    }
}