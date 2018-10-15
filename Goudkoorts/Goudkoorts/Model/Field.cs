using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public abstract class Field
    {
        private Random _randomGen;
        public char Symbol { get; set; }
        public Field Next { get; set; }

        public Entity Entity { get; set; }

        public Field()
        {
            _randomGen = new Random();
        }

        public abstract void PutEntityOnThisField(Route route);

        public bool ReleaseCart()
        {
            int number = _randomGen.Next(1, 100);

            if (number < 26)
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
