using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Controller
{
    class MainController
    {
        private OutputView outputView;
        private InputView inputView;
        public MainController()
        {
            outputView = new OutputView();
            outputView.PrintWelcomeMessage();
            inputView = new InputView();
            Console.ReadLine();
        }
    }
}
