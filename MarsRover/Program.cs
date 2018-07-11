using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            MarsRoverProgram mrp = new MarsRoverProgram();

            while (true)
            {
                Console.Write("Enter Grid Size (Eg: 5,5) >");
                string gs = Console.ReadLine();
                mrp.InitialiseGrid(gs);

                Console.Write("Enter Starting Co-Ordinates (Eg: 0,0,N) >");
                string sp = Console.ReadLine();
                mrp.InitialiseStartLocation(sp);

                Console.Write("Enter Movement Path (Eg: LMLMRMMLM >");
                string mp = Console.ReadLine();

                Console.WriteLine("Calculating End Position....");

                string ep = mrp.CalculateEndPosition(mp);
                Console.WriteLine("End Position is...{0}", ep);

                Console.WriteLine();
                Console.WriteLine("Press Enter To Go Again or 'q' To Quit: ");

                if (Console.ReadLine().ToUpper() == "Q")
                    break;
            }
            
        }
    }
}
