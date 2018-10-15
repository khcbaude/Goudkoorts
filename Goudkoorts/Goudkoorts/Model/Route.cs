using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Route
    {
        public List<Field> Warehouses = new List<Field>();

        public List<Entity> Entities { get; set; }

        public void addCart()
        {
            for(int i = 0; i < Warehouses.Count; i++)
            {
                if (Warehouses[i].ReleaseCart()) {
                    Cart c = new Cart();
                    Warehouses[i].Next.Entity = c;
                }
            }
        }
    }
}
