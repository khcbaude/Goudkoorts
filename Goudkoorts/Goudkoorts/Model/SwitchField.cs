using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class SwitchField : Field
    {

        public bool FirstPressed { get; set; }

        public bool SecondPressed { get; set; }


        public SwitchField(char symbol)
        {
            Symbol = symbol;
        }

        public override bool PutEntityOnThisField(Route route, Field previous)
        {
            if (Entity == null)
            {
                if (CheckForFirstSwitch())
                {
                    Entity = SecondPrevious.Entity;
                    SecondPrevious.Entity = null;
                    return true;
                }
                Entity = FirstPrevious.Entity;
                FirstPrevious.Entity = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckForFirstSwitch()
        {
            if (FirstPressed)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        public bool CheckForSecondSwitch()
        {
            if (SecondPressed)
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
