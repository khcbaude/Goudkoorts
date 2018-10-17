using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public abstract class Entity
    {
        public bool IsFull { get; set; }

        public int Counter { get; set; }

        protected char _symbol;
        public abstract char Symbol { get; set; }

        public abstract bool CheckForFull();

    }
}
