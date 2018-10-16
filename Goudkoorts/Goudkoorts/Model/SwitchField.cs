using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class SwitchField : Field
    {
        
        public bool Pressed { get; set; }

        public SwitchField(char symbol)
        {
            Symbol = symbol;
        }

        public override bool PutEntityOnThisField(Route route, Field previous)
        {
            if (Entity == null)
            {
                if (ChangeSwitch())
                {
                    
                }
                Entity = previous.Entity;
                previous.Entity = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangeSwitch()
        {
            if (Pressed)
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
