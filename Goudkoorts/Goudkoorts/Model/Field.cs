using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public abstract class Field
    {
        private char _symbol;
        public char Symbol
        {
            get
            {
                if (Entity != null)
                {
                    return Entity.Symbol;
                }
                else
                {
                    return _symbol;
                }
            }
            set { _symbol = value; }
        }
        public Field Next { get; set; }

        public Entity Entity { get; set; }

        public Field()
        {
        }

        public abstract bool PutEntityOnThisField(Route route, Field previous);
        
    }
}
