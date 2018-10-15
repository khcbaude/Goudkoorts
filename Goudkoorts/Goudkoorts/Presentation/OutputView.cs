using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class OutputView
    {
        public void PrintWelcomeMessage()
        {
            Console.WriteLine("____________________________________");
            Console.WriteLine("|          Welcome to              |");
            Console.WriteLine("|           Goldfever              |");
            Console.WriteLine("|   Symbol      |     Meaning      |");
            Console.WriteLine("|     ═         |      Field       |");
            Console.WriteLine("|     O         |     EmptyCart    |");
            Console.WriteLine("|     0         |     FullCart     |");
            Console.WriteLine("|     █         |     Warehouse    |");
            Console.WriteLine("|     ░         |      Water       |");
            Console.WriteLine("|  ╚ ╔ ╗ ╝      |     Switches     |");
            Console.WriteLine("|   Numbers     |      Boat        |");
            Console.WriteLine("|     ~         |   ReangentField  |");
            Console.WriteLine("|     K         |      Wharf       |");
            Console.WriteLine(" __________________________________ ");
        }
    }
}
