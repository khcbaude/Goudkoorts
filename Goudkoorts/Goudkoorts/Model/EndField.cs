using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class EndField : Field
    {
        public override char Symbol { get; set; }
        public override Field Next { get; set; }

        public EndField(char symbol)
        {
            Symbol = symbol;
        }

        public override bool PutEntityOnThisField(Route route, Field previous, List<Field> fields)
        {
            if (previous.Entity.CheckForFull())
            {
                route.Score += 10;
                route.AddBoat();
            }
            fields.Remove(previous);
            previous.Entity = null;
            return false;
        }
    }
}
