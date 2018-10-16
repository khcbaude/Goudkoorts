using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class RegularField : Field
    {

        public RegularField(char symbol)
        {
            Symbol = symbol;
        }

        public override bool PutEntityOnThisField(Route route, Field previous)
        {
            if (Entity == null)
            {
                Entity = previous.Entity;
                previous.Entity = null;
                return true;
            }
            else
            {
                if(previous.FirstNext.FirstNext != null)
                {
                    Console.WriteLine("Botsing!");
                    return false;
                }
                return false;
            }
        }
    }
}
