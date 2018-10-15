using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Cart : Entity
    {
        public override char Symbol
        {
            get
            {
                if (IsFull)
                {
                    return '▼';
                }
                else
                {

                    return Symbol;
                }
            }
            set { }
        }
        public Cart()
        {
            Symbol = 'V';
        }
    }
}
