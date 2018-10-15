﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Cart : Entity
    {
        public Cart()
        {
            Symbol = 'V';
            if (IsFull)
            {
                Symbol = '▼';
            }
        }
    }
}
