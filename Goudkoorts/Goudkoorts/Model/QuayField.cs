using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class QuayField : Field
    { 
        public QuayField(char symbol)
        {
            Symbol = symbol;
        }

        public override char Symbol { get
            {
                if(Entity != null)
                {
                    return Entity.Symbol;
                } else
                {
                    return _symbol;
                }
            }
            set { _symbol = value; }
        }
        public override Field Next { get; set; }

        public override bool PutEntityOnThisField(Route route, Field previous)
        {
            if (Entity == null)
            {
                Entity = previous.Entity;
                previous.Entity = null;
                Entity.IsFull = false;
                route._ship.Counter++;
                return true;
            }
            else
            {
                if (previous.Next.Next != null)
                {
                    Console.WriteLine("Botsing!");
                    return false;
                }
                return false;
            }
        }
    }
}
