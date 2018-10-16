using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class EmptyField : Field
    {
        public EmptyField(char symbol)
        {
            Symbol = symbol;
        }
        public override bool PutEntityOnThisField(Route route, Field previous)
        {
            return false;
        }
    }
}
