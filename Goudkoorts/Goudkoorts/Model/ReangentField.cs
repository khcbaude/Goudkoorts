﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class ReangentField : Field
    {

        public ReangentField(char symbol)
        {
            Symbol = symbol;
        }

        public override void PutEntityOnThisField(Route route)
        {
            throw new NotImplementedException();
        }
    }
}
