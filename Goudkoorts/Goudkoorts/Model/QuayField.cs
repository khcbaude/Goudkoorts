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

        public override bool PutEntityOnThisField(Route route, Field previous, List<Field> fields)
        {
            if (Entity == null)
            {
                if (route.ShipOnQuay != null)
                {
                    if (route.ShipOnQuay.Counter != 8)
                    {
                        Entity = previous.Entity;
                        previous.Entity = null;
                        Entity.IsFull = false;
                        route.ShipOnQuay.Counter++;
                        return true;
                    }
                }
                return false;
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
