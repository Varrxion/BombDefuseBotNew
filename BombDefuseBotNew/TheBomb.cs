using System;

namespace TheBomb
{
    static internal class TheBomb
    {
        //Bomb Variables
        static public int Serialnumodd = -1; //0 is false, 1 is true, -1 means unchecked
        static public int Batterynum = -1;
        static public int indicatorCAR = -1;
        static public int indicatorFRK = -1;
        static public int hasvowel = -1;
        static public int hasparallelport = -1;

        static public void ModList()
        {
            Console.WriteLine("\nwires, button, keypad, simon, whosfirst, memory, morse, complicated wires, wire sequence\n");
        }
        static public void ComList()
        {
            Console.WriteLine("\nmost of these functions other than bombcheck are there in case you typed something in wrong\n" +
                "bombcheck, which runs through all bomb variables such as batteries and indicators\n" +
                "serialnum, which lets you manually set the serial number\n" +
                "batterynum, which lets you manually set the battery number\n" +
                "carset, which lets you manually set the lit indicator CAR\n" +
                "frkset, which lets you manually set the lit indicator FRK\n" +
                "vowelset, which lets you manually set if the serial number has a vowel\n" +
                "parallelset, which lets you manually set if the bomb has a parallel port\n");
        }

        static public void BombCheck() //The option to set all bomb variables initially rather than as they are needed
        {
            Serialnumset();
            vowelset();
            Batterynumset();
            indicatorCARset();
            indicatorFRKset();
            parallelportset();
        }
        static public void Serialnumset()
        {
            string isodd = "unset";
            Console.Write("Is the last digit of the serial number odd, yes or no? ");
            while (isodd != "yes" && isodd != "no")
            {
                isodd = Console.ReadLine();
                if (isodd != "yes" && isodd != "no")
                {
                    Console.Write("Invalid Input, try again ");
                }
            }
            if (isodd == "yes")
            {
                Serialnumodd = 1;
            }
            else
            {
                Serialnumodd = 0;
            }
        }
        static public void Batterynumset()
        {
            bool validinput = false;
            int batterynum = -1;
            Console.Write("How many batteries on the bomb? ");
            while (!validinput)
            {
                if (int.TryParse(Console.ReadLine(), out batterynum))
                {
                    if (batterynum >= 0) //Check if number is equal to or greater than 0
                    {
                        validinput = true;
                    }
                }
                if (!validinput)
                {
                    Console.Write("Invalid Input, try again ");
                }
            }
            Batterynum = batterynum;
        }
        static public void indicatorCARset()
        {
            string indicatorlitCAR = "unset";
            Console.Write("Is there a lit indicator CAR on the bomb, yes or no? ");
            while (indicatorlitCAR != "yes" && indicatorlitCAR != "no")
            {
                indicatorlitCAR = Console.ReadLine();
                if (indicatorlitCAR != "yes" && indicatorlitCAR != "no")
                {
                    Console.Write("Invalid Input, try again ");
                }
            }
            if (indicatorlitCAR == "yes")
            {
                indicatorCAR = 1;
            }
            else
            {
                indicatorCAR = 0;
            }
        }
        static public void indicatorFRKset()
        {
            string indicatorlitFRK = "unset";
            Console.Write("Is there a lit indicator FRK on the bomb, yes or no? ");
            while (indicatorlitFRK != "yes" && indicatorlitFRK != "no")
            {
                indicatorlitFRK = Console.ReadLine();
                if (indicatorlitFRK != "yes" && indicatorlitFRK != "no")
                {
                    Console.Write("Invalid Input, try again ");
                }
            }
            if (indicatorlitFRK == "yes")
            {
                indicatorFRK = 1;
            }
            else
            {
                indicatorFRK = 0;
            }
        }
        static public void vowelset()
        {
            string isvowel = "unset";
            Console.Write("Is there a vowel in the serial number, yes or no? ");
            while (isvowel != "yes" && isvowel != "no")
            {
                isvowel = Console.ReadLine();
                if (isvowel != "yes" && isvowel != "no")
                {
                    Console.Write("Invalid Input, try again ");
                }
            }
            if (isvowel == "yes")
            {
                hasvowel = 1;
            }
            else
            {
                hasvowel = 0;
            }
        }
        static public void parallelportset()
        {
            string parallelport = "unset";
            Console.Write("Is there a parallel port on the bomb, yes or no? ");
            while (parallelport != "yes" && parallelport != "no")
            {
                parallelport = Console.ReadLine();
                if (parallelport != "yes" && parallelport != "no")
                {
                    Console.Write("Invalid Input, try again ");
                }
            }
            if (parallelport == "yes")
            {
                hasparallelport = 1;
            }
            else
            {
                hasparallelport = 0;
            }
        }
    }
}
