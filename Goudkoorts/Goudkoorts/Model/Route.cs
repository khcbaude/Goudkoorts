﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Route
    {
        private Random _randomGen;
        public List<Warehouse> Warehouses { get; set; }
        public List<Field> Entities { get; set; }
        public List<SwitchField> Switches { get; set; }

        public Entity ShipOnQuay { get; set; }

        public List<WaterField> Waterfields { get; set; }

        public int Score { get; set; }

        public bool Game { get; set; }

        public Route()
        {
            Warehouses = new List<Warehouse>();
            Entities = new List<Field>();
            Switches = new List<SwitchField>();
            Waterfields = new List<WaterField>();
            _randomGen = new Random();
            Game = true;
        }

        public void AddCart()
        {
            for (int i = 0; i < Warehouses.Count; i++)
            {
                if (Warehouses[i].ReleaseCart(_randomGen))
                {
                    Cart cart = new Cart();
                    Warehouses[i].Next.Entity = cart;
                    Entities.Add(Warehouses[i].Next);
                }
            }
        }

        public void AddBoat()
        {
            Ship ship = new Ship();
            Waterfields[0].Entity = ship;
            Entities.Add(Waterfields[0]);
        }

        public void RandomChanceBoat()
        {
            int number = _randomGen.Next(1,100);
            if (number > 0&& number < 2 && Waterfields[0].Entity == null)
            {
                Ship ship = new Ship();
                Waterfields[0].Entity = ship;
                Entities.Add(Waterfields[0]);
            }
        }

        public void MoveEntities()
        {
            for (int k = 0; k < Entities.Count; k++)
            {
                if (Waterfields[Waterfields.Count-3].Entity != null) {
                    if (Entities[k].Entity.Equals(Waterfields[Waterfields.Count - 3].Entity))
                    {
                        if (Entities[k].Entity.CheckForFull())
                        {
                            if (Entities[k].Next != null)
                            {
                                if (Entities[k].Next.PutEntityOnThisField(this, Entities[k], Entities))
                                {
                                    Entities[k] = Entities[k].Next;
                                    ShipOnQuay = null;
                                    continue;
                                }
                            }
                        }
                        continue;
                    }
                }
                if (Entities[k].Next != null)
                {
                    if (Entities[k].Next.PutEntityOnThisField(this, Entities[k], Entities))
                    {
                        Entities[k] = Entities[k].Next;
                        if (Entities[k].Equals(Waterfields[Waterfields.Count - 3]))
                        {
                            ShipOnQuay = Entities[k].Entity;
                        }
                    }
                }
            }
        }
    }
}
