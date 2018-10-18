using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class EmptyField : Field
    {
        public override char Symbol
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
        public EmptyField(char symbol)
        {
            Symbol = symbol;
        }

        public override Field Next { get; set; }

        public override bool PutEntityOnThisField(Route route, Field previous, List<Field> fields)
        {
            return false;
        }
    }
}
