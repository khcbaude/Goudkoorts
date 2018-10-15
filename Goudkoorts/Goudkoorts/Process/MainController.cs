using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Process
{
    class MainController
    {
        public int Score { get; set; }

        private OutputView _outputView;
        private InputView _inputView;
        private Parser _parser;
        public MainController()
        {
            _outputView = new OutputView();
            _outputView.PrintWelcomeMessage();
            _inputView = new InputView();
            _parser = new Parser();
            _outputView.Print = _parser.BuildMaze();
            _outputView.PrintField();
            Console.ReadLine();
        }
    }
}
