using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Warehouse : Field
    {
        private Random randomGen;

        public Warehouse()
        {
            randomGen = new Random();
        }

        

        public override void PutEntityOnThisField(Route route) { return; }
    }
}
