using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Ship : Entity
    {
        public int CartAmount { get; set; }
        public override char Symbol
        {
            get
            {
                if (IsFull)
                {
                    return '0';
                }
                else
                {

                    return _symbol;
                }
            }
            set { _symbol = value; }
        }
        public Ship()
        {
            IsFull = false;
            Symbol = 'O';
        }

        public override bool CheckForFull()
        {
            if(Counter == 8)
            {
                IsFull = true;
            }
            return IsFull;
        }
    }
}
