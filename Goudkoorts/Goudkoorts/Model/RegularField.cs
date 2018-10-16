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

        public override void PutEntityOnThisField(Route route)
        {
            throw new NotImplementedException();
        }
    }
}
