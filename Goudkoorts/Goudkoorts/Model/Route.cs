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

        public List<Entity> Entities { get; set; }

        public Route()
        {
            Warehouses = new List<Warehouse>();
            Entities = new List<Entity>();
            _randomGen = new Random();
        }

        public void AddCart()
        {
            for(int i = 0; i < Warehouses.Count; i++)
            {
                if (Warehouses[i].ReleaseCart(_randomGen)) {
                    Cart cart = new Cart();
                    Warehouses[i].Next.Entity = cart;
                    Entities.Add(cart);
                }
            }
        }
    }
}
