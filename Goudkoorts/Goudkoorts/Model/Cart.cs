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
                    return 'F';
                }
                else
                {

                    return _symbol;
                }
            }
            set { _symbol = value; }
        }
        public Cart()
        {
            IsFull = true;
            Symbol = 'E';
        }

        public override bool CheckForFull()
        {
            return false;
        }
    }
}
