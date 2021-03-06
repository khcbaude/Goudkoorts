﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class WaterField : Field
    {
        public WaterField(char symbol)
        {
            Symbol = symbol;
            Quay = false;
        }

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

        public bool Quay { get; set; }
        public override Field Next { get; set; }

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
                    Console.WriteLine("Botsing!");
                    return false;
                }
                return false;
            }
        }
    }
}
