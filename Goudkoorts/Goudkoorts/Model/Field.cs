using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public abstract class Field
    {
        protected char _symbol;
        public abstract char Symbol { get; set; }
        public abstract Field Next { get; set; }

        public Entity Entity { get; set; }

        public Field()
        {
        }

        public abstract bool PutEntityOnThisField(Route route, Field previous, List<Field> fields);
        
    }
}
