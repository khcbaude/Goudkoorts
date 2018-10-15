using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    abstract public class Entity
    {
        public bool IsFull { get; set; }

        abstract public char Symbol { get; set; }

    }
}
