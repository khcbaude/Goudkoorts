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
            mainThread = new Thread(new ThreadStart(Run));
            mainThread.Start();
            SwitchInput();
            Console.ReadLine();
        }

        private void Run()
        {
            _parser.Route.AddBoat();
            while (true)
            {
                Thread.Sleep(1000);
                Time++; 
                Console.Clear();
                _parser.Route.MoveEntities();
                _parser.Route.AddCart();
                _parser.Route.RandomChanceBoat();
                Console.WriteLine(Time);
                _outputView.PrintField(_parser.Route.Score);
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
                _outputView.PrintField(_parser.Route.Score);
            }
        }
    }
}
