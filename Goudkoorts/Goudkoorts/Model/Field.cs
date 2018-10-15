using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public abstract class Field
    {
        public char Symbol { get; set; }
        public Field Next { get; set; }

        public abstract void PutEntityOnThisField(Route route);
    }
}
