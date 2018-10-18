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
        private Model.Route _route;
        public MainController()
        {
            _outputView = new OutputView();
            _outputView.PrintWelcomeMessage();
            _inputView = new InputView();
            _parser = new Parser();
            _outputView.Print = _parser.BuildMaze();
            _route = _parser.Route;
            mainThread = new Thread(new ThreadStart(Run));
            mainThread.Start();
            SwitchInput();
            mainThread.Interrupt();
            _outputView.WriteEndGameMessage(_route.Score);
            Console.ReadLine();
        }

        private void Run()
        {
            _route.AddBoat();
            while (_route.Game)
            {
                Thread.Sleep(1000);
                Time++; 
                Console.Clear();
                _route.MoveEntities();
                _route.AddCart();
                _route.RandomChanceBoat();
                Console.WriteLine(Time);
                _outputView.PrintField(_route.Score);
            }
        }

        private void SwitchInput()
        {
            while (_route.Game)
            {
                int input = _inputView.ReturnInput(_route);
                if (input == 0) { break; }
                Console.Clear();
                if (_route.Switches[input - 1].FirstPressed)
                {
                    _route.Switches[input - 1].FirstPressed = false;
                }
                else
                {
                    _route.Switches[input - 1].FirstPressed = true;
                }
                _outputView.PrintField(_route.Score);
            }
        }
    }
}
