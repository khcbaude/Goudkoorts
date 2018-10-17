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

        public Route()
        {
            Warehouses = new List<Warehouse>();
            Entities = new List<Field>();
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

        public void MoveEntities()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].Next != null)
                {
                    if (Entities[i].Next.PutEntityOnThisField(this, Entities[i]))
                    {
                        Entities[i] = Entities[i].Next;
                    }
                }
            }
        }
    }
}
