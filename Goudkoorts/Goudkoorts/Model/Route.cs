using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Route
    {
        public List<Warehouse> Warehouses { get; set; }

        public List<Entity> Entities { get; set; }
    }
}
