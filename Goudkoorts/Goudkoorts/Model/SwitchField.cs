using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class SwitchField : Field
    {
        public override Field Next
        {
            get
            {
                if (FirstPressed)
                {
                    return FirstNext;
                }
                else
                {
                    return SecondNext;
                }
            }
            set { }
        }

        public override char Symbol
        {
            //╚ ╔ ╗ ╝
            get
            {
                if (Entity != null)
                {
                    return Entity.Symbol;
                }

                if (FirstNext == SecondNext)
                {
                    if (FirstPressed)
                    {
                        return '╚';
                    }
                    else { return '╔'; }
                }
                else
                {
                    if (FirstPressed)
                    {
                        return '╝';
                    }
                    else { return '╗'; }
                }
            }
            set { _symbol = value; }
        }
        public bool FirstPressed { get; set; }

        public Field FirstNext { get; set; }

        public Field SecondNext { get; set; }

        public Field FirstPrevious { get; set; }

        public Field SecondPrevious { get; set; }
        public SwitchField(char symbol)
        {
            Symbol = symbol;
            FirstPressed = false;
        }

        public override bool PutEntityOnThisField(Route route, Field previous)
        {
            if (FirstPressed)
            {
                if (!previous.Equals(FirstPrevious)) { return false; }
            }
            else
            {
                if (!previous.Equals(SecondPrevious)) { return false; }
            }
            if (Entity == null)
            {
                Entity = previous.Entity;
                previous.Entity = null;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
