using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Ship : Entity
    {
        public override char Symbol
        {
            get
            {
                switch (Counter)
                {
                    case 0: return '0';
                    case 1: return '1';
                    case 2: return '2';
                    case 3: return '3';
                    case 4: return '4';
                    case 5: return '5';
                    case 6: return '6';
                    case 7: return '7';
                    case 8: return '8';
                    default: return ' ';
                }
            }
            set { }
        }
        public Ship()
        {
            IsFull = false;
            Symbol = 'O';
            Counter = 0;
        }

        public override bool CheckForFull()
        {
            if (Counter == 8)
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
