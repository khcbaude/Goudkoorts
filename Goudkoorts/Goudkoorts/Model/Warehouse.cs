using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Warehouse : Field
    {

        public Warehouse(char symbol)
        {
            Symbol = symbol;
        }

        public override bool PutEntityOnThisField(Route route, Field previous) { return false; }
        public bool ReleaseCart(Random randomGen)
        {
            int number = randomGen.Next(1, 100);

            if (number < 26)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
