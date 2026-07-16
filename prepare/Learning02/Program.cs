using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        Job job2 = new Job();
        job2._company = "IRONWOOD INSIGHTS GROUP";
        job2._jobTitle = "Survey Caller";
        job2._startYear = 2026;
        job2._endYear = 2026;
        job1._company = "BYUI";
        job1._jobTitle = "Teaching Assistant"; 
        job1._startYear = 2026;
        job1._endYear = 2026; 

        Resume resume1 = new Resume();
        resume1.name = "Jay Davis";
        resume1.jobs.Add(job1);
        resume1.jobs.Add(job2);

        resume1.DisplayTitles();
        
    }
}