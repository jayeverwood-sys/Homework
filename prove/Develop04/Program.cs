using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathe = new BreathingActivity();
        ReflectionActivity reflect = new ReflectionActivity();
        ListingActivity listing = new ListingActivity();
        int Num = 0;

        while (Num != 4)
        {
            Console.WriteLine("\n 1) Breathing Activity \n 2) Reflecting Activity \n 3) Listing Activity \n 4) QUIT! \n What option do you want to do?: ");
            Num = int.Parse(Console.ReadLine());

            switch (Num)
            {
                case 1:
                    breathe.GuideBreathing();
                    break;
                case 2:
                    reflect.HumbleReflect();
                    break;
                case 3:
                    listing.ManyItems();
                    break;
                case 4:
                    break;
            }
        }
    }
}