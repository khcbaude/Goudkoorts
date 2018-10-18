using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class OutputView
    {
        public List<Model.Field> Print { get; set; }
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

        internal void WriteEndGameMessage(int score)
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine("Final Score: " + score);
            Console.WriteLine("Press Enter to close game");
        }

        public void PrintField(int score)
        {
            Console.WriteLine();
            Model.Field[] characters = Print.ToArray();
            int count = 0;
            for (int i = 0; i < Print.Count; i++)
            {
                Console.Write(characters[i].Symbol);
                count++;
                if (count == 16)
                {
                    Console.WriteLine();
                    count = 0;
                }
            }
            Console.WriteLine("Score: " + score);
        }
    }
}
