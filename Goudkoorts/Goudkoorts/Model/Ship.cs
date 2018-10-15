using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Ship : Entity
    {
        public Ship()
        {
            Symbol = '▭';
            if (IsFull)
            {
                Symbol = '▬';
            }
        }
    }
}
