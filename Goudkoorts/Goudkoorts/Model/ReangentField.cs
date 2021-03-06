﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class ReangentField : Field
    {
        public override char Symbol
        {
            get
            {
                if (Entity != null)
                {
                    return Entity.Symbol;
                }
                else
                {
                    return _symbol;
                }
            }
            set { _symbol = value; }
        }
        public override Field Next { get; set; }

        public ReangentField(char symbol)
        {
            Symbol = symbol;
        }

        public override bool PutEntityOnThisField(Route route, Field previous, List<Field> fields)
        {
            if (Entity == null)
            {
                Entity = previous.Entity;
                previous.Entity = null;
                return true;
            }
            else
            {
                if (previous.Next.Next != null)
                {
                    Console.WriteLine("Geen botsing want dit is een reangentfield!");
                    return false;
                }
                return false;
            }
        }
    }
}
