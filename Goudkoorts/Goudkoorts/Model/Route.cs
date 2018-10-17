using System;
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

        private Ship _ship;

        public List<WaterField> Waterfields { get; set; }

        public Route()
        {
            Warehouses = new List<Warehouse>();
            Entities = new List<Field>();
            Switches = new List<SwitchField>();
            Waterfields = new List<WaterField>();
            _randomGen = new Random();
        }

        public void AddCart()
        {
            for(int i = 0; i < Warehouses.Count; i++)
            {
                if (Warehouses[i].ReleaseCart(_randomGen)) {
                    Cart cart = new Cart();
                    Warehouses[i].Next.Entity = cart;
                    Entities.Add(Warehouses[i].Next);
                }
            }
        }

        public void AddBoat()
        {
            _ship = new Ship();
            Waterfields[0].Entity = _ship;
            Entities.Add(Waterfields[0]);
        }

        public void MoveEntities()
        {
            int k;
            for (k = 0; k < Entities.Count; k++)
            {
                if (_ship.Equals(Waterfields[Waterfields.Count-3].Entity))
                {
                    if (_ship.IsFull)
                    {
                        continue;
                    } else
                    {
                        // schip moet stoppen but idk how
                        break;
                    }
                }
                if (Entities[k].Next != null)
                {
                    if (Entities[k].Next.PutEntityOnThisField(this, Entities[k]))
                    {
                        Entities[k] = Entities[k].Next;
                        if (Entities[k].Entity.CheckForFull())
                        {
                            _ship.IsFull = true;
                        }
                    }
                }
            }
            k++;
            for(int i = k; i < Entities.Count; i++)
            {
                if (Entities[i].Next != null)
                {
                    if (Entities[i].Next.PutEntityOnThisField(this, Entities[i]))
                    {
                        Entities[i] = Entities[i].Next;
                        if (Entities[i].Entity.CheckForFull())
                        {
                            _ship.IsFull = true;
                        }
                    }
                }
            }
        }
    }
}
