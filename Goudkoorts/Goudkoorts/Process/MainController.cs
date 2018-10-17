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

        public int Time { get; set; }

        private Thread mainThread;

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
            mainThread = new Thread(new ThreadStart(Run));
            mainThread.Start();
            SwitchInput();
            Console.ReadLine();
        }

        private void Run()
        {
            while (true)
            {
                Thread.Sleep(3000);
                Time++; 
                Console.Clear();
                _parser.Route.MoveEntities();
                _parser.Route.AddCart();
                Console.WriteLine(Time);
                _outputView.PrintField();
            }
        }

        private void SwitchInput()
        {
            while (true)
            {
                int input = _inputView.ReturnInput();
                Console.Clear();
                if (_parser.Route.Switches[input - 1].FirstPressed)
                {
                    _parser.Route.Switches[input - 1].FirstPressed = false;
                }
                else
                {
                    _parser.Route.Switches[input - 1].FirstPressed = true;
                }
                _outputView.PrintField();
            }
        }
    }
}
