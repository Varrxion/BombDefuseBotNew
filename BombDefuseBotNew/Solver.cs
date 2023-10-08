using System;

namespace Solver
{
    static internal class Modules
    {
        static public void wires()
        {
            string[] wirecolorarr = new string[6];
            bool validinput = false;
            int wirenum = -1;
            Console.Write("How many wires? ");
            while (!validinput)
            {
                if (int.TryParse(Console.ReadLine(), out wirenum))
                {
                    if (wirenum >= 3 && wirenum <= 6) //Check if number is between or including 3 through 6
                    {
                        validinput = true;
                    }
                }
                if (!validinput)
                {
                    Console.Write("Invalid Input, try again ");
                }
            }

            int wireindex = 0;
            string wirecolor = "none";

            while (wireindex < wirenum)
            {
                Console.Write($"What is the color of wire number {wireindex + 1}? ");
                wirecolor = Console.ReadLine();
                if (wirecolor == "red" || wirecolor == "yellow" || wirecolor == "blue" || wirecolor == "black" || wirecolor == "white")
                {
                    wirecolorarr[wireindex] = wirecolor;
                    wireindex++;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }

            if (wirenum == 3)
            {
                if (Utilities.wirecolorcount(wirecolorarr, "red") == 0)
                {
                    Console.WriteLine("Cut the second wire");
                }
                else if (wirecolorarr[wirenum - 1] == "white")
                {
                    Console.WriteLine("Cut the last wire");
                }
                else if (Utilities.wirecolorcount(wirecolorarr, "blue") > 1)
                {
                    Console.WriteLine("Cut the last blue wire");
                }
                else
                {
                    Console.WriteLine("Cut the last wire");
                }
            }
            else if (wirenum == 4)
            {
                if (TheBomb.TheBomb.Serialnumodd == -1)
                {
                    TheBomb.TheBomb.Serialnumset();
                }
                if (Utilities.wirecolorcount(wirecolorarr, "red") > 1 && TheBomb.TheBomb.Serialnumodd == 1)
                {
                    Console.WriteLine("Cut the last red wire");
                }
                else if (Utilities.wirecolorcount(wirecolorarr, "red") == 0 && wirecolorarr[wirenum - 1] == "yellow")
                {
                    Console.WriteLine("Cut the first wire");
                }
                else if (Utilities.wirecolorcount(wirecolorarr, "blue") == 1)
                {
                    Console.WriteLine("Cut the first wire");
                }
                else if (Utilities.wirecolorcount(wirecolorarr, "yellow") > 1)
                {
                    Console.WriteLine("Cut the last wire");
                }
                else
                {
                    Console.WriteLine("Cut the second wire");
                }
            }
            else if (wirenum == 5)
            {
                if (TheBomb.TheBomb.Serialnumodd == -1)
                {
                    TheBomb.TheBomb.Serialnumset();
                }
                if (wirecolorarr[wirenum - 1] == "black" && TheBomb.TheBomb.Serialnumodd == 1)
                {
                    Console.WriteLine("Cut the fourth wire");
                }
                else if (Utilities.wirecolorcount(wirecolorarr, "red") == 1 && Utilities.wirecolorcount(wirecolorarr, "yellow") > 1)
                {
                    Console.WriteLine("Cut the first wire");
                }
                else if (Utilities.wirecolorcount(wirecolorarr, "black") == 0)
                {
                    Console.WriteLine("Cut the second wire");
                }
                else
                {
                    Console.WriteLine("Cut the first wire");
                }
            }
            else
            {
                if (TheBomb.TheBomb.Serialnumodd == -1)
                {
                    TheBomb.TheBomb.Serialnumset();
                }
                if (Utilities.wirecolorcount(wirecolorarr, "yellow") == 0 && TheBomb.TheBomb.Serialnumodd == 1)
                {
                    Console.WriteLine("Cut the third wire");
                }
                else if (Utilities.wirecolorcount(wirecolorarr, "yellow") == 1 && Utilities.wirecolorcount(wirecolorarr, "white") > 1)
                {
                    Console.WriteLine("Cut the fourth wire");
                }
                else if (Utilities.wirecolorcount(wirecolorarr, "red") == 0)
                {
                    Console.WriteLine("Cut the last wire");
                }
                else
                {
                    Console.WriteLine("Cut the fourth wire");
                }
            }
        }
        static public void thebutton()
        {
            string buttonword = "none";
            string buttoncolor = "none";
            bool validinput = false;
            Console.Write("What color is the button? ");

            while (!validinput)
            {
                buttoncolor = Console.ReadLine();
                if (buttoncolor == "red" || buttoncolor == "yellow" || buttoncolor == "blue" || buttoncolor == "white")
                {
                    validinput = true;
                }
                else
                {
                    Console.Write("Invalid Input, try again ");
                }
            }

            validinput = false;
            Console.Write("What word is on the button? (no caps) ");
            while (!validinput)
            {
                buttonword = Console.ReadLine();
                if (buttonword == "press" || buttonword == "hold" || buttonword == "abort" || buttonword == "detonate")
                {
                    validinput = true;
                }
                else
                {
                    Console.Write("Invalid Input, try again ");
                }
            }

            if (TheBomb.TheBomb.Batterynum == -1)
            {
                TheBomb.TheBomb.Batterynumset();
            }
            if (TheBomb.TheBomb.indicatorCAR == -1)
            {
                TheBomb.TheBomb.indicatorCARset();
            }
            if (TheBomb.TheBomb.indicatorFRK == -1)
            {
                TheBomb.TheBomb.indicatorFRKset();
            }

            if (buttoncolor == "blue" && buttonword == "abort")
            {
                Console.WriteLine("Hold the button\nIf blue strip: Release at 4\nIf yellow strip: Release at 5\nIf other strip: Release at 1");
            }
            else if (TheBomb.TheBomb.Batterynum > 1 && buttonword == "detonate")
            {
                Console.WriteLine("Press and immediately release the button");
            }
            else if (buttoncolor == "white" && TheBomb.TheBomb.indicatorCAR == 1)
            {
                Console.WriteLine("Hold the button\nIf blue strip: Release at 4\nIf yellow strip: Release at 5\nIf other strip: Release at 1");
            }
            else if (TheBomb.TheBomb.Batterynum > 2 && TheBomb.TheBomb.indicatorFRK == 1)
            {
                Console.WriteLine("Press and immediately release the button");
            }
            else if (buttoncolor == "yellow")
            {
                Console.WriteLine("Hold the button\nIf blue strip: Release at 4\nIf yellow strip: Release at 5\nIf other strip: Release at 1");
            }
            else if (buttoncolor == "red" && buttonword == "Hold")
            {
                Console.WriteLine("Press and immediately release the button");
            }
            else
            {
                Console.WriteLine("Hold the button\nIf blue strip: Release at 4\nIf yellow strip: Release at 5\nIf other strip: Release at 1");
            }
        }
        static public void keypad()
        {
            Console.WriteLine("Please refer to the Bomb Manual");
        }
        static public void simon()
        {
            bool validinput = false;
            int strikenum = -1;

            if (TheBomb.TheBomb.hasvowel == -1)
            {
                TheBomb.TheBomb.vowelset();
            }

            Console.Write("How many strikes do you have? ");
            while (!validinput)
            {
                if (int.TryParse(Console.ReadLine(), out strikenum))
                {
                    if (strikenum >= 0 && strikenum <= 2) //Check if number is between or including 0 through 2
                    {
                        validinput = true;
                    }
                }
                if (!validinput)
                {
                    Console.Write("Invalid Input, try again ");
                }
            }

            if (TheBomb.TheBomb.hasvowel == 1)
            {
                if (strikenum == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nRed");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Blue");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Blue");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Red");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Green");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Yellow");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Yellow");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Green");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n");
                }
                else if (strikenum == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nRed");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Yellow");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Blue");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Green");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Green");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Blue");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Yellow");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Red");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nRed");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Green");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Blue");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Red");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Green");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Yellow");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Yellow");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Blue");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n");
                }
            }
            else
            {
                if (strikenum == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nRed");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Blue");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Blue");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Yellow");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Green");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Green");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Yellow");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Red");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n");
                }
                else if (strikenum == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nRed");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Red");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Blue");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Blue");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Green");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Yellow");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Yellow");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Green");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nRed");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Yellow");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Blue");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Green");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Green");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Blue");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Yellow");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" means ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Red");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n");
                    //Console.WriteLine("\nRed means Yellow, Blue means Green, Green means Blue, Yellow means Red\n");
                }
            }
        }
        static public void whosfirst()
        {
            string topword = "unset";
            string buttonword = "unset";
            bool validinput = false;

            Console.Write("What is the display word? ");
            while (!validinput)
            {
                topword = Console.ReadLine();
                if (topword == "yes" || topword == "first" || topword == "display" || topword == "okay" || topword == "says" || topword == "nothing" || topword == "" || topword == "blank" || topword == "no" || topword == "led" || topword == "lead" || topword == "read" || topword == "red" || topword == "reed" || topword == "leed" || topword == "hold on" || topword == "you" || topword == "you are" || topword == "your" || topword == "you're" || topword == "ur" || topword == "there" || topword == "they're" || topword == "their" || topword == "they are" || topword == "see" || topword == "c" || topword == "cee")
                {
                    validinput = true;
                }
                else
                {
                    Console.Write("Invalid Input, try again ");
                }
            }
            validinput = false;

            if (topword == "yes" || topword == "nothing" || topword == "led" || topword == "they are")
            {
                Console.Write("What is the mid left word? ");
                while (!validinput)
                {
                    buttonword = Console.ReadLine();
                    if (buttonword == "ready" || buttonword == "first" || buttonword == "no" || buttonword == "blank" || buttonword == "nothing" || buttonword == "yes" || buttonword == "what" || buttonword == "uhhh" || buttonword == "left" || buttonword == "right" || buttonword == "middle" || buttonword == "okay" || buttonword == "wait" || buttonword == "press" || buttonword == "you" || buttonword == "you are" || buttonword == "your" || buttonword == "you're" || buttonword == "ur" || buttonword == "u" || buttonword == "uh huh" || buttonword == "uh uh" || buttonword == "what?" || buttonword == "done" || buttonword == "next" || buttonword == "hold" || buttonword == "sure" || buttonword == "like")
                    {
                        validinput = true;
                    }
                    else
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                Utilities.whosfirstwordschecker(buttonword);
            }
            else if (topword == "first" || topword == "okay" || topword == "c")
            {
                Console.Write("What is the top right word? ");
                while (!validinput)
                {
                    buttonword = Console.ReadLine();
                    if (buttonword == "ready" || buttonword == "first" || buttonword == "no" || buttonword == "blank" || buttonword == "nothing" || buttonword == "yes" || buttonword == "what" || buttonword == "uhhh" || buttonword == "left" || buttonword == "right" || buttonword == "middle" || buttonword == "okay" || buttonword == "wait" || buttonword == "press" || buttonword == "you" || buttonword == "you are" || buttonword == "your" || buttonword == "you're" || buttonword == "ur" || buttonword == "u" || buttonword == "uh huh" || buttonword == "uh uh" || buttonword == "what?" || buttonword == "done" || buttonword == "next" || buttonword == "hold" || buttonword == "sure" || buttonword == "like")
                    {
                        validinput = true;
                    }
                    else
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                Utilities.whosfirstwordschecker(buttonword);
            }
            else if (topword == "display" || topword == "says" || topword == "no" || topword == "lead" || topword == "hold on" || topword == "you are" || topword == "there" || topword == "see" || topword == "cee")
            {
                Console.Write("What is the bottom right word? ");
                while (!validinput)
                {
                    buttonword = Console.ReadLine();
                    if (buttonword == "ready" || buttonword == "first" || buttonword == "no" || buttonword == "blank" || buttonword == "nothing" || buttonword == "yes" || buttonword == "what" || buttonword == "uhhh" || buttonword == "left" || buttonword == "right" || buttonword == "middle" || buttonword == "okay" || buttonword == "wait" || buttonword == "press" || buttonword == "you" || buttonword == "you are" || buttonword == "your" || buttonword == "you're" || buttonword == "ur" || buttonword == "u" || buttonword == "uh huh" || buttonword == "uh uh" || buttonword == "what?" || buttonword == "done" || buttonword == "next" || buttonword == "hold" || buttonword == "sure" || buttonword == "like")
                    {
                        validinput = true;
                    }
                    else
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                Utilities.whosfirstwordschecker(buttonword);
            }
            else if (topword == "" || topword == "reed" || topword == "leed" || topword == "they're")
            {
                Console.Write("What is the bottom left word? ");
                while (!validinput)
                {
                    buttonword = Console.ReadLine();
                    if (buttonword == "ready" || buttonword == "first" || buttonword == "no" || buttonword == "blank" || buttonword == "nothing" || buttonword == "yes" || buttonword == "what" || buttonword == "uhhh" || buttonword == "left" || buttonword == "right" || buttonword == "middle" || buttonword == "okay" || buttonword == "wait" || buttonword == "press" || buttonword == "you" || buttonword == "you are" || buttonword == "your" || buttonword == "you're" || buttonword == "ur" || buttonword == "u" || buttonword == "uh huh" || buttonword == "uh uh" || buttonword == "what?" || buttonword == "done" || buttonword == "next" || buttonword == "hold" || buttonword == "sure" || buttonword == "like")
                    {
                        validinput = true;
                    }
                    else
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                Utilities.whosfirstwordschecker(buttonword);
            }
            else if (topword == "blank" || topword == "read" || topword == "red" || topword == "you" || topword == "your" || topword == "you're" || topword == "their")
            {
                Console.Write("What is the mid right word? ");
                while (!validinput)
                {
                    buttonword = Console.ReadLine();
                    if (buttonword == "ready" || buttonword == "first" || buttonword == "no" || buttonword == "blank" || buttonword == "nothing" || buttonword == "yes" || buttonword == "what" || buttonword == "uhhh" || buttonword == "left" || buttonword == "right" || buttonword == "middle" || buttonword == "okay" || buttonword == "wait" || buttonword == "press" || buttonword == "you" || buttonword == "you are" || buttonword == "your" || buttonword == "you're" || buttonword == "ur" || buttonword == "u" || buttonword == "uh huh" || buttonword == "uh uh" || buttonword == "what?" || buttonword == "done" || buttonword == "next" || buttonword == "hold" || buttonword == "sure" || buttonword == "like")
                    {
                        validinput = true;
                    }
                    else
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                Utilities.whosfirstwordschecker(buttonword);
            }
            else
            {
                Console.Write("What is the top left word? ");
                while (!validinput)
                {
                    buttonword = Console.ReadLine();
                    if (buttonword == "ready" || buttonword == "first" || buttonword == "no" || buttonword == "blank" || buttonword == "nothing" || buttonword == "yes" || buttonword == "what" || buttonword == "uhhh" || buttonword == "left" || buttonword == "right" || buttonword == "middle" || buttonword == "okay" || buttonword == "wait" || buttonword == "press" || buttonword == "you" || buttonword == "you are" || buttonword == "your" || buttonword == "you're" || buttonword == "ur" || buttonword == "u" || buttonword == "uh huh" || buttonword == "uh uh" || buttonword == "what?" || buttonword == "done" || buttonword == "next" || buttonword == "hold" || buttonword == "sure" || buttonword == "like")
                    {
                        validinput = true;
                    }
                    else
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                Utilities.whosfirstwordschecker(buttonword);
            }
        }
        static public void memory()
        {
            int displaynum = -1;
            int step1num = -1; int step2num = -1; int step3num = -1; int step4num = -1;
            int step1pos = -1; int step2pos = -1; int step3pos = -1;
            Console.Write("What is the number on the display? ");

            bool validinput = false;
            while (!validinput)
            {
                if (int.TryParse(Console.ReadLine(), out displaynum))
                {
                    if (displaynum >= 1 && displaynum <= 4) //Check if number is between or including 1 through 4
                    {
                        validinput = true;
                    }
                }
                if (!validinput)
                {
                    Console.Write("Invalid Input, try again ");
                }
            }
            validinput = false;

            // Stage 1
            if (displaynum == 1 || displaynum == 2)
            {
                Console.Write("What is the label of the button position 2? ");

                while (!validinput)
                {
                    if (int.TryParse(Console.ReadLine(), out step1num))
                    {
                        if (step1num >= 1 && step1num <= 4) //Check if number is between or including 1 through 4
                        {
                            validinput = true;
                        }
                    }
                    if (!validinput)
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }

                step1pos = 2;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press the button in position 2");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (displaynum == 3)
            {
                Console.Write("What is the label of the button in position 3? ");

                while (!validinput)
                {
                    if (int.TryParse(Console.ReadLine(), out step1num))
                    {
                        if (step1num >= 1 && step1num <= 4) //Check if number is between or including 1 through 4
                        {
                            validinput = true;
                        }
                    }
                    if (!validinput)
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }

                step1pos = 3;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press the button in position 3");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else
            {
                Console.Write("What is the label of the button in position 4? ");

                while (!validinput)
                {
                    if (int.TryParse(Console.ReadLine(), out step1num))
                    {
                        if (step1num >= 1 && step1num <= 4) //Check if number is between or including 1 through 4
                        {
                            validinput = true;
                        }
                    }
                    if (!validinput)
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }

                step1pos = 4;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press the button in position 4");
                Console.ForegroundColor = ConsoleColor.White;
            }
            validinput = false;

            // Stage 2
            Console.Write("What is the number on the display? ");
            while (!validinput)
            {
                if (int.TryParse(Console.ReadLine(), out displaynum))
                {
                    if (displaynum >= 1 && displaynum <= 4) //Check if number is between or including 1 through 4
                    {
                        validinput = true;
                    }
                }
                if (!validinput)
                {
                    Console.Write("Invalid Input, try again ");
                }
            }
            validinput = false;

            if (displaynum == 1)
            {
                Console.Write("What position is the button labeled 4 in? ");

                while (!validinput)
                {
                    if (int.TryParse(Console.ReadLine(), out step2pos))
                    {
                        if (step2pos >= 1 && step2pos <= 4) //Check if number is between or including 1 through 4
                        {
                            validinput = true;
                        }
                    }
                    if (!validinput)
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }

                step2num = 4;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press the button labeled 4");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (displaynum == 2 || displaynum == 4)
            {
                Console.Write($"What is the label of the button in position {step1pos}? ");

                while (!validinput)
                {
                    if (int.TryParse(Console.ReadLine(), out step2num))
                    {
                        if (step2num >= 1 && step2num <= 4) //Check if number is between or including 1 through 4
                        {
                            validinput = true;
                        }
                    }
                    if (!validinput)
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }

                step2pos = step1pos;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Press the button in position {step1pos}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else
            {
                Console.Write("What is the label of the button in position 1? ");

                while (!validinput)
                {
                    if (int.TryParse(Console.ReadLine(), out step2num))
                    {
                        if (step2num >= 1 && step2num <= 4) //Check if number is between or including 1 through 4
                        {
                            validinput = true;
                        }
                    }
                    if (!validinput)
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }

                step2pos = 1;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press the button in position 1");
                Console.ForegroundColor = ConsoleColor.White;
            }

            validinput = false;

            // Stage 3
            Console.Write("What is the number on the display? ");
            while (!validinput)
            {
                if (int.TryParse(Console.ReadLine(), out displaynum))
                {
                    if (displaynum >= 1 && displaynum <= 4) //Check if number is between or including 1 through 4
                    {
                        validinput = true;
                    }
                }
                if (!validinput)
                {
                    Console.Write("Invalid Input, try again ");
                }
            }
            validinput = false;

            if (displaynum == 1)
            {
                Console.Write($"What is the position of the button labeled {step2num}? ");

                while (!validinput)
                {
                    if (int.TryParse(Console.ReadLine(), out step3pos))
                    {
                        if (step3pos >= 1 && step3pos <= 4) //Check if number is between or including 1 through 4
                        {
                            validinput = true;
                        }
                    }
                    if (!validinput)
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }

                step3num = step2num;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Press the button labeled {step2num}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (displaynum == 2)
            {
                Console.Write($"What is the position of the button labeled {step1num}? ");

                while (!validinput)
                {
                    if (int.TryParse(Console.ReadLine(), out step3pos))
                    {
                        if (step3pos >= 1 && step3pos <= 4) //Check if number is between or including 1 through 4
                        {
                            validinput = true;
                        }
                    }
                    if (!validinput)
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }

                step3num = step1num;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Press the button labeled {step1num}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (displaynum == 3)
            {
                Console.Write("What is the label of the button in position 3? ");

                while (!validinput)
                {
                    if (int.TryParse(Console.ReadLine(), out step3num))
                    {
                        if (step3num >= 1 && step3num <= 4) //Check if number is between or including 1 through 4
                        {
                            validinput = true;
                        }
                    }
                    if (!validinput)
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }

                step3pos = 3;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press the button in position 3");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else
            {
                Console.Write("What is the position of the button labeled 4? ");

                while (!validinput)
                {
                    if (int.TryParse(Console.ReadLine(), out step3pos))
                    {
                        if (step3pos >= 1 && step3pos <= 4) //Check if number is between or including 1 through 4
                        {
                            validinput = true;
                        }
                    }
                    if (!validinput)
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }

                step3num = 4;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press the button labeled 4");
                Console.ForegroundColor = ConsoleColor.White;
            }
            validinput = false;

            // Stage 4
            Console.Write("What is the number on the display? ");
            while (!validinput)
            {
                if (int.TryParse(Console.ReadLine(), out displaynum))
                {
                    if (displaynum >= 1 && displaynum <= 4) //Check if number is between or including 1 through 4
                    {
                        validinput = true;
                    }
                }
                if (!validinput)
                {
                    Console.Write("Invalid Input, try again ");
                }
            }
            validinput = false;

            if (displaynum == 1)
            {
                Console.Write($"What is the label of the button in position {step1pos}? ");

                while (!validinput)
                {
                    if (int.TryParse(Console.ReadLine(), out step4num))
                    {
                        if (step4num >= 1 && step4num <= 4) //Check if number is between or including 1 through 4
                        {
                            validinput = true;
                        }
                    }
                    if (!validinput)
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Press the button in position {step1pos}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (displaynum == 2)
            {
                Console.Write("What is the label of the button in position 1? ");

                while (!validinput)
                {
                    if (int.TryParse(Console.ReadLine(), out step4num))
                    {
                        if (step4num >= 1 && step4num <= 4) //Check if number is between or including 1 through 4
                        {
                            validinput = true;
                        }
                    }
                    if (!validinput)
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Press the button in position 1");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else
            {
                Console.Write($"What is the label of the button in position {step2pos}? ");

                while (!validinput)
                {
                    if (int.TryParse(Console.ReadLine(), out step4num))
                    {
                        if (step4num >= 1 && step4num <= 4) //Check if number is between or including 1 through 4
                        {
                            validinput = true;
                        }
                    }
                    if (!validinput)
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Press the button in position {step2pos}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            validinput = false;

            // Stage 5
            Console.Write("What is the number on the display? ");
            while (!validinput)
            {
                if (int.TryParse(Console.ReadLine(), out displaynum))
                {
                    if (displaynum >= 1 && displaynum <= 4) //Check if number is between or including 1 through 4
                    {
                        validinput = true;
                    }
                }
                if (!validinput)
                {
                    Console.Write("Invalid Input, try again ");
                }
            }
            validinput = false;

            if (displaynum == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Press the button labeled {step1num}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (displaynum == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Press the button labeled {step2num}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (displaynum == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Press the button labeled {step4num}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Press the button labeled {step3num}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static public void morse()
        {
            string morseinput = "unset";
            bool morsedone = false;
            Console.WriteLine("A short flash represents a ./dot. A long flash represents a -/dash.");
            Console.WriteLine("A long gap will be between letters, and a very long gap will occur before the word repeats.");
            Console.Write("Please input morse, or type list: ");
            while (morsedone == false)
            {
                morseinput = Console.ReadLine();
                if (morseinput == "... .... . .-.. .-..")
                { //Shell
                    Console.WriteLine("Respond at frequency 3.505MHz");
                    morsedone = true;
                }
                else if (morseinput == ".... .- .-.. .-.. ...")
                { //Halls
                    Console.WriteLine("Respond at frequency 3.515MHz");
                    morsedone = true;
                }
                else if (morseinput == "... .-.. .. -.-. -.-")
                { //Slick
                    Console.WriteLine("Respond at frequency 3.522MHz");
                    morsedone = true;
                }
                else if (morseinput == "- .-. .. -.-. -.-")
                { //Trick
                    Console.WriteLine("Respond at frequency 3.532MHz");
                    morsedone = true;
                }
                else if (morseinput == "-... --- -..- . ...")
                { //Boxes
                    Console.WriteLine("Respond at frequency 3.535MHz");
                    morsedone = true;
                }
                else if (morseinput == ".-.. . .- -.- ...")
                { //Leaks
                    Console.WriteLine("Respond at frequency 3.542MHz");
                    morsedone = true;
                }
                else if (morseinput == "... - .-. --- -... .")
                { //Strobe
                    Console.WriteLine("Respond at frequency 3.545MHz");
                    morsedone = true;
                }
                else if (morseinput == "-... .. ... - .-. ---")
                { //Bistro
                    Console.WriteLine("Respond at frequency 3.552MHz");
                    morsedone = true;
                }
                else if (morseinput == "..-. .-.. .. -.-. -.-")
                { //Flick
                    Console.WriteLine("Respond at frequency 3.555MHz");
                    morsedone = true;
                }
                else if (morseinput == "-... --- -- -... ...")
                { //Bombs
                    Console.WriteLine("Respond at frequency 3.565MHz");
                    morsedone = true;
                }
                else if (morseinput == "-... .-. . .- -.-")
                { //Break
                    Console.WriteLine("Respond at frequency 3.572MHz");
                    morsedone = true;
                }
                else if (morseinput == "-... .-. .. -.-. -.-")
                { //Brick
                    Console.WriteLine("Respond at frequency 3.575MHz");
                    morsedone = true;
                }
                else if (morseinput == "... - . .- -.-")
                { //Steak
                    Console.WriteLine("Respond at frequency 3.582MHz");
                    morsedone = true;
                }
                else if (morseinput == "... - .. -. --.")
                { //Sting
                    Console.WriteLine("Respond at frequency 3.592MHz");
                    morsedone = true;
                }
                else if (morseinput == "...- . -.-. - --- .-.")
                { //Vector
                    Console.WriteLine("Respond at frequency 3.595MHz");
                    morsedone = true;
                }
                else if (morseinput == "-... . .- - ...")
                { //Beats
                    Console.WriteLine("Respond at frequency 3.600MHz");
                    morsedone = true;
                }
                else if (morseinput == "list")
                {
                    Console.WriteLine("... .... . .-.. .-.."); //Shell
                    Console.WriteLine("Respond at frequency 3.505MHz");
                    Console.WriteLine(".... .- .-.. .-.. ..."); //Halls
                    Console.WriteLine("Respond at frequency 3.515MHz");
                    Console.WriteLine("... .-.. .. -.-. -.-"); //Slick
                    Console.WriteLine("Respond at frequency 3.522MHz");
                    Console.WriteLine("- .-. .. -.-. -.-"); //Trick
                    Console.WriteLine("Respond at frequency 3.532MHz");
                    Console.WriteLine("-... --- -..- . ..."); //Boxes
                    Console.WriteLine("Respond at frequency 3.535MHz");
                    Console.WriteLine(".-.. . .- -.- ..."); //Leaks
                    Console.WriteLine("Respond at frequency 3.542MHz");
                    Console.WriteLine("... - .-. --- -... ."); //Strobe
                    Console.WriteLine("Respond at frequency 3.545MHz");
                    Console.WriteLine("-... .. ... - .-. ---"); //Bistro
                    Console.WriteLine("Respond at frequency 3.552MHz");
                    Console.WriteLine("..-. .-.. .. -.-. -.-"); //Flick
                    Console.WriteLine("Respond at frequency 3.555MHz");
                    Console.WriteLine("-... --- -- -... ..."); //Bombs
                    Console.WriteLine("Respond at frequency 3.565MHz");
                    Console.WriteLine("-... .-. . .- -.-"); //Break
                    Console.WriteLine("Respond at frequency 3.572MHz");
                    Console.WriteLine("-... .-. .. -.-. -.-"); //Brick
                    Console.WriteLine("Respond at frequency 3.575MHz");
                    Console.WriteLine("... - . .- -.-"); //Steak
                    Console.WriteLine("Respond at frequency 3.582MHz");
                    Console.WriteLine("... - .. -. --."); //Sting
                    Console.WriteLine("Respond at frequency 3.592MHz");
                    Console.WriteLine("...- . -.-. - --- .-."); //Vector
                    Console.WriteLine("Respond at frequency 3.595MHz");
                    Console.WriteLine("-... . .- - ..."); //Beats
                    Console.WriteLine("Respond at frequency 3.600MHz");
                    morsedone = true;
                }
                else
                { //Error Handler
                    Console.Write("Invalid Input, try again ");
                }
            }
        }
        static public void complicatedwires()
        {
            string isdone = "def";
            string wirered = "unset", wireblue = "unset", hasstar = "unset", hasled = "unset";
            if (TheBomb.TheBomb.Serialnumodd == -1)
            {
                TheBomb.TheBomb.Serialnumset();
            }
            if (TheBomb.TheBomb.Batterynum == -1)
            {
                TheBomb.TheBomb.Batterynumset();
            }
            if (TheBomb.TheBomb.hasparallelport == -1)
            {
                TheBomb.TheBomb.parallelportset();
            }
            Console.WriteLine("All complicated wire questions are yes or no, PER WIRE");
            while (isdone == "def" || isdone == "next")
            {
                Console.Write("Is the wire red? ");
                while (wirered != "yes" && wirered != "no")
                {
                    wirered = Console.ReadLine();
                    if (wirered != "yes" && wirered != "no")
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                Console.Write("Is the wire blue? ");
                while (wireblue != "yes" && wireblue != "no")
                {
                    wireblue = Console.ReadLine();
                    if (wireblue != "yes" && wireblue != "no")
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                Console.Write("Is there a star? ");
                while (hasstar != "yes" && hasstar != "no")
                {
                    hasstar = Console.ReadLine();
                    if (hasstar != "yes" && hasstar != "no")
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                Console.Write("Is the LED lit? ");
                while (hasled != "yes" && hasled != "no")
                {
                    hasled = Console.ReadLine();
                    if (hasled != "yes" && hasled != "no")
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                Utilities.complicatedwireschecker(wirered, wireblue, hasstar, hasled);
                wirered = "unset"; wireblue = "unset"; hasstar = "unset"; hasled = "unset";
                isdone = "def";
                Console.Write("Type next or done: ");
                while (isdone != "next" && isdone != "done")
                {
                    isdone = Console.ReadLine();
                    if (isdone != "next" && isdone != "done")
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
            }
        }
        static public void wiresequence()
        {
            int redcounter = 0, bluecounter = 0, blackcounter = 0;
            bool isdone = false;
            string wirecolor = "unset";
            bool validinput = false;
            Console.WriteLine("Wire sequence is per wire questions, and when done answer done for wire color when the entire module is complete\nYou MUST re-call the module if there are multiple wire sequence modules, as per the bomb manual");
            while (!isdone)
            {
                Console.Write("What is the color of the wire? ");
                while (!validinput)
                {

                    wirecolor = Console.ReadLine();
                    if (wirecolor == "red" || wirecolor == "blue" || wirecolor == "black")
                    {
                        validinput = true;
                        if (wirecolor == "red")
                        {
                            redcounter++;
                            Utilities.wiresequencechecker(wirecolor, redcounter);
                        }
                        else if (wirecolor == "blue")
                        {
                            bluecounter++;
                            Utilities.wiresequencechecker(wirecolor, bluecounter);
                        }
                        else
                        {
                            blackcounter++;
                            Utilities.wiresequencechecker(wirecolor, blackcounter);
                        }
                    }
                    else if (wirecolor == "done")
                    {
                        validinput = true;
                    }
                    else
                    {
                        Console.Write("Invalid Input, try again ");
                    }
                }
                if (wirecolor == "done")
                {
                    isdone = true;
                }
                validinput = false;
            }
        }
    }
    static internal class Utilities
    {
        static public int wirecolorcount(string[] wirecolorarr, string colorcheck)
        {
            int howmany = 0;
            if (wirecolorarr[0] == colorcheck)
            {
                howmany++;
            }
            if (wirecolorarr[1] == colorcheck)
            {
                howmany++;
            }
            if (wirecolorarr[2] == colorcheck)
            {
                howmany++;
            }
            if (wirecolorarr[3] == colorcheck)
            {
                howmany++;
            }
            if (wirecolorarr[4] == colorcheck)
            {
                howmany++;
            }
            if (wirecolorarr[5] == colorcheck)
            {
                howmany++;
            }
            return howmany;
        }
        static public void whosfirstwordschecker(string buttonword)
        {
            if (buttonword == "ready")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("YES, OKAY, WHAT, MIDDLE, LEFT, PRESS, RIGHT, BLANK, READY, NO, FIRST, UHHH, NOTHING, WAIT\n");
            }
            else if (buttonword == "first")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("LEFT, OKAY, YES, MIDDLE, NO, RIGHT, NOTHING, UHHH, WAIT, READY, BLANK, WHAT, PRESS, FIRST\n");
            }
            else if (buttonword == "no")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("BLANK, UHHH, WAIT, FIRST, WHAT, READY, RIGHT, YES, NOTHING, LEFT, PRESS, OKAY, NO, MIDDLE\n");
            }
            else if (buttonword == "blank")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("WAIT, RIGHT, OKAY, MIDDLE, BLANK, PRESS, READY, NOTHING, NO, WHAT, LEFT, UHHH, YES, FIRST\n");
            }
            else if (buttonword == "nothing")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("UHHH, RIGHT, OKAY, MIDDLE, YES, BLANK, NO, PRESS, LEFT, WHAT, WAIT, FIRST, NOTHING, READY\n");
            }
            else if (buttonword == "yes")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("OKAY, RIGHT, UHHH, MIDDLE, FIRST, WHAT, PRESS, READY, NOTHING, YES, LEFT, BLANK, NO, WAIT\n");
            }
            else if (buttonword == "what")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("UHHH, WHAT, LEFT, NOTHING, READY, BLANK, MIDDLE, NO, OKAY, FIRST, WAIT, YES, PRESS, RIGHT\n");
            }
            else if (buttonword == "uhhh")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("READY, NOTHING, LEFT, WHAT, OKAY, YES, RIGHT, NO, PRESS, BLANK, UHHH, MIDDLE, WAIT, FIRST\n");
            }
            else if (buttonword == "left")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("RIGHT, LEFT, FIRST, NO, MIDDLE, YES, BLANK, WHAT, UHHH, WAIT, PRESS, READY, OKAY, NOTHING\n");
            }
            else if (buttonword == "right")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("YES, NOTHING, READY, PRESS, NO, WAIT, WHAT, RIGHT, MIDDLE, LEFT, UHHH, BLANK, OKAY, FIRST\n");
            }
            else if (buttonword == "middle")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("BLANK, READY, OKAY, WHAT, NOTHING, PRESS, NO, WAIT, LEFT, MIDDLE, RIGHT, FIRST, UHHH, YES\n");
            }
            else if (buttonword == "okay")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("MIDDLE, NO, FIRST, YES, UHHH, NOTHING, WAIT, OKAY, LEFT, READY, BLANK, PRESS, WHAT, RIGHT\n");
            }
            else if (buttonword == "wait")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("UHHH, NO, BLANK, OKAY, YES, LEFT, FIRST, PRESS, WHAT, WAIT, NOTHING, READY, RIGHT, MIDDLE\n");
            }
            else if (buttonword == "press")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("RIGHT, MIDDLE, YES, READY, PRESS, OKAY, NOTHING, UHHH, BLANK, LEFT, FIRST, WHAT, NO, WAIT\n");
            }
            else if (buttonword == "you")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("SURE, YOU ARE, YOUR, YOU'RE, NEXT, UH HUH, UR, HOLD, WHAT?, YOU, UH UH, LIKE, DONE, U\n");
            }
            else if (buttonword == "you are")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("YOUR, NEXT, LIKE, UH HUH, WHAT?, DONE, UH UH, HOLD, YOU, U, YOU'RE, SURE, UR, YOU ARE\n");
            }
            else if (buttonword == "your")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("UH UH, YOU ARE, UH HUH, YOUR, NEXT, UR, SURE, U, YOU'RE, YOU, WHAT?, HOLD, LIKE, DONE\n");
            }
            else if (buttonword == "you're")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("YOU, YOU'RE, UR, NEXT, UH UH, YOU ARE, U, YOUR, WHAT?, UH HUH, SURE, DONE, LIKE, HOLD\n");
            }
            else if (buttonword == "ur")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("DONE, U, UR, UH HUH, WHAT?, SURE, YOUR, HOLD, YOU'RE, LIKE, NEXT, UH UH, YOU ARE, YOU\n");
            }
            else if (buttonword == "u")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("UH HUH, SURE, NEXT, WHAT?, YOU'RE, UR, UH UH, DONE, U, YOU, LIKE, HOLD, YOU ARE, YOUR\n");
            }
            else if (buttonword == "uh huh")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("UH HUH, YOUR, YOU ARE, YOU, DONE, HOLD, UH UH, NEXT, SURE, LIKE, YOU'RE, UR, U, WHAT?\n");
            }
            else if (buttonword == "uh uh")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("UR, U, YOU ARE, YOU'RE, NEXT, UH UH, DONE, YOU, UH HUH, LIKE, YOUR, SURE, HOLD, WHAT?\n");
            }
            else if (buttonword == "what?")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("YOU, HOLD, YOU'RE, YOUR, U, DONE, UH UH, LIKE, YOU ARE, UH HUH, UR, NEXT, WHAT?, SURE\n");
            }
            else if (buttonword == "done")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("SURE, UH HUH, NEXT, WHAT?, YOUR, UR, YOU'RE, HOLD, LIKE, YOU, U, YOU ARE, UH UH, DONE\n");
            }
            else if (buttonword == "next")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("WHAT?, UH HUH, UH UH, YOUR, HOLD, SURE, NEXT, LIKE, DONE, YOU ARE, UR, YOU'RE, U, YOU\n");
            }
            else if (buttonword == "hold")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("YOU ARE, U, DONE, UH UH, YOU, UR, SURE, WHAT?, YOU'RE, NEXT, HOLD, UH HUH, YOUR, LIKE\n");
            }
            else if (buttonword == "sure")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("YOU ARE, DONE, LIKE, YOU'RE, YOU, HOLD, UH HUH, UR, SURE, U, WHAT?, NEXT, YOUR, UH UH\n");
            }
            else if (buttonword == "like")
            {
                Console.WriteLine("Push the button with the first word that appears in this list\n");
                Console.WriteLine("YOU'RE, NEXT, U, UR, HOLD, DONE, UH UH, WHAT?, UH HUH, YOU, LIKE, SURE, YOU ARE, YOUR\n");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }
        static public void complicatedwireschecker(string wirered, string wireblue, string hasstar, string hasled)
        {
            if ((wirered == "no" && wireblue == "no" && hasstar == "no" && hasled == "no") || (wirered == "yes" && wireblue == "no" && hasstar == "yes" && hasled == "no") || (wirered == "no" && wireblue == "no" && hasstar == "yes" && hasled == "no"))
            {
                Console.WriteLine("Cut the wire");
            }
            else if ((wirered == "yes" && wireblue == "yes" && hasstar == "yes" && hasled == "yes") || (wirered == "no" && wireblue == "no" && hasstar == "no" && hasled == "yes") || (wirered == "yes" && wireblue == "yes" && hasstar == "yes" && hasled == "no"))
            {
                Console.WriteLine("Do not cut the wire");
            }
            else if (((wirered == "yes" && wireblue == "no" && hasstar == "no" && hasled == "no") || (wirered == "no" && wireblue == "yes" && hasstar == "no" && hasled == "no") || (wirered == "yes" && wireblue == "yes" && hasstar == "no" && hasled == "no") || (wirered == "yes" && wireblue == "yes" && hasstar == "no" && hasled == "yes")) && (TheBomb.TheBomb.Serialnumodd == 0))
            {
                Console.WriteLine("Cut the wire");
            }
            else if (((wirered == "no" && wireblue == "yes" && hasstar == "no" && hasled == "yes") || (wirered == "yes" && wireblue == "yes" && hasstar == "yes" && hasled == "no") || (wirered == "no" && wireblue == "yes" && hasstar == "yes" && hasled == "yes")) && (TheBomb.TheBomb.hasparallelport == 1))
            {
                Console.WriteLine("Cut the wire");
            }
            else if (((wirered == "yes" && wireblue == "no" && hasstar == "no" && hasled == "yes") || (wirered == "yes" && wireblue == "no" && hasstar == "yes" && hasled == "yes") || (wirered == "no" && wireblue == "no" && hasstar == "yes" && hasled == "yes")) && (TheBomb.TheBomb.Batterynum >= 2))
            {
                Console.WriteLine("Cut the wire");
            }
            else
            {
                Console.WriteLine("Do not cut the wire");
            }
        }
        static public void wiresequencechecker(string wirecolor, int counter)
        {
            if (wirecolor == "red")
            {
                if (counter == 1)
                {
                    Console.WriteLine("Cut if connected to C");
                }
                else if (counter == 2)
                {
                    Console.WriteLine("Cut if connected to B");
                }
                else if (counter == 3)
                {
                    Console.WriteLine("Cut if connected to A");
                }
                else if (counter == 4)
                {
                    Console.WriteLine("Cut if connected to A or C");
                }
                else if (counter == 5)
                {
                    Console.WriteLine("Cut if connected to B");
                }
                else if (counter == 6)
                {
                    Console.WriteLine("Cut if connected to A or C");
                }
                else if (counter == 7)
                {
                    Console.WriteLine("Cut the wire");
                }
                else if (counter == 8)
                {
                    Console.WriteLine("Cut if connected to A or B");
                }
                else if (counter == 9)
                {
                    Console.WriteLine("Cut if connected to B");
                }
                else
                {
                    Console.WriteLine("Something is wrong, you probably didn't re-call the module");
                }
            }
            if (wirecolor == "blue")
            {
                if (counter == 1)
                {
                    Console.WriteLine("Cut if connected to B");
                }
                else if (counter == 2)
                {
                    Console.WriteLine("Cut if connected to A or C");
                }
                else if (counter == 3)
                {
                    Console.WriteLine("Cut if connected to B");
                }
                else if (counter == 4)
                {
                    Console.WriteLine("Cut if connected to A");
                }
                else if (counter == 5)
                {
                    Console.WriteLine("Cut if connected to B");
                }
                else if (counter == 6)
                {
                    Console.WriteLine("Cut if connected to B or C");
                }
                else if (counter == 7)
                {
                    Console.WriteLine("Cut if connected to C");
                }
                else if (counter == 8)
                {
                    Console.WriteLine("Cut if connected to A or C");
                }
                else if (counter == 9)
                {
                    Console.WriteLine("Cut if connected to A");
                }
                else
                {
                    Console.WriteLine("Something is wrong, you probably didn't re-call the module");
                }
            }
            if (wirecolor == "black")
            {
                if (counter == 1)
                {
                    Console.WriteLine("Cut the wire");
                }
                else if (counter == 2)
                {
                    Console.WriteLine("Cut if connected to A or C");
                }
                else if (counter == 3)
                {
                    Console.WriteLine("Cut if connected to B");
                }
                else if (counter == 4)
                {
                    Console.WriteLine("Cut if connected to A or C");
                }
                else if (counter == 5)
                {
                    Console.WriteLine("Cut if connected to B");
                }
                else if (counter == 6)
                {
                    Console.WriteLine("Cut if connected to B or C");
                }
                else if (counter == 7)
                {
                    Console.WriteLine("Cut if connected to A or B");
                }
                else if (counter == 8)
                {
                    Console.WriteLine("Cut if connected to C");
                }
                else if (counter == 9)
                {
                    Console.WriteLine("Cut if connected to C");
                }
                else
                {
                    Console.WriteLine("Something is wrong, you probably didn't re-call the module");
                }
            }
        }
    }
}
