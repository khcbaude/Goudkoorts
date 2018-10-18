using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class InputView
    {

        public int ReturnInput(Model.Route route)
        {
            int intTemp = 0;
            while (route.Game)
            {
                string s = Console.ReadLine();
                if (int.TryParse(s, out intTemp))
                {

                    intTemp = Convert.ToInt32(s);
                    if (intTemp > 0 && intTemp < 6)
                    {
                        return intTemp;
                    }

                }

                Console.WriteLine("Ongeldige input");
            }
            return 0;
        }
    }
}
