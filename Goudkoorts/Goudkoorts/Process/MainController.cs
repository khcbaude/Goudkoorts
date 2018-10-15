using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goudkoorts.Process
{
    class MainController
    {
        public int Score { get; set; }

        public static int Time { get; set; }

        private Timer t = new Timer(DisplayTimeEvent, null, 0, 1000);

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

        
        private static void DisplayTimeEvent(object o)
        {
            Time = Time + 1;
            Console.Clear();
            OutputView ov = new OutputView();
            Parser p = new Parser();
            ov.Print = p.BuildMaze();
            ov.PrintField();
            Console.WriteLine(Time);
            
        }
        
    }
}
