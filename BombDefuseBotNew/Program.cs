using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string appname = "KTANE Bomb Defusal Bot";
            string appversion = "1.0.0";
            string appauthor = "Channel_4";

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"{appname}: Version {appversion} by {appauthor}");

            bool isdone = false;
            Console.WriteLine("Type modlist to get a list of module names\nType comlist to get a list of commands\nType done when there are no more modules left\n");
            string modname = "none";

            while (!isdone)
            {
                Console.Write("Please input module name: "); //Get user to pick module
                modname = Console.ReadLine();

                if (modname == "bombcheck") //bombcheck is checked first
                {
                    TheBomb.TheBomb.BombCheck();
                }

                else if (modname == "wires") //start modules
                {
                    Solver.Modules.wires();
                }
                else if (modname == "button")
                {
                    Solver.Modules.thebutton();
                }
                else if (modname == "keypad")
                {
                    Solver.Modules.keypad();
                }
                else if (modname == "simon")
                {
                    Solver.Modules.simon();
                }
                else if (modname == "whosfirst")
                {
                    Solver.Modules.whosfirst();
                    Solver.Modules.whosfirst();
                    Solver.Modules.whosfirst();
                }
                else if (modname == "memory")
                {
                    Solver.Modules.memory();
                }
                else if (modname == "morse")
                {
                    Solver.Modules.morse();
                }
                else if (modname == "complicated wires") //end modules
                {
                    Solver.Modules.complicatedwires();
                }
                else if (modname == "wire sequence")
                {
                    Solver.Modules.wiresequence();
                }

                else if (modname == "modlist") //start list checks
                {
                    TheBomb.TheBomb.ModList();
                }
                else if (modname == "comlist") //end list checks
                {
                    TheBomb.TheBomb.ComList();
                }

                else if (modname == "serialnum") //start commands
                {
                    TheBomb.TheBomb.Serialnumset();
                }
                else if (modname == "batterynum")
                {
                    TheBomb.TheBomb.Batterynumset();
                }
                else if (modname == "carset")
                {
                    TheBomb.TheBomb.indicatorCARset();
                }
                else if (modname == "frkset")
                {
                    TheBomb.TheBomb.indicatorFRKset();
                }
                else if (modname == "vowelset") //end commands
                {
                    TheBomb.TheBomb.vowelset();
                }

                else if (modname == "done") //finish check
                {
                    isdone = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input, type list for a list of module names");
                }
            }
            Console.WriteLine("Bomb has been defused");
        }
    }
}
