using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Process
{
    class Parser
    {
        public Model.Route Route { get; set; }
        public void BuildMaze()
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath = Directory.GetParent(_filePath).FullName;
            _filePath = Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName;
            _filePath += @"\Goudkoorts\Map\Map1.txt";
            TextReader tr = new StreamReader(_filePath);

            string line;
            List<string> list = new List<string>();

            while ((line = tr.ReadLine()) != null)
            {
                list.Add(line);
                Console.WriteLine(line);
            }

            char[] characters = list[0].ToArray();
            Route = new Model.Route();
            Model.Field[,] fields = new Model.Field[list.Count, characters.Length];
            for (int i =0; i < list.Count; i++)
            {
                characters = list[i].ToArray();
                for (int j = 0; j < characters.Length; j++)
                {
                    switch (characters[j])
                    {
                        case '░':
                            fields[i, j] = new Model.EmptyField();
                            fields[i, j].Symbol = '░';
                            break;
                        case 'K':
                            fields[i, j] = new Model.EmptyField();
                            fields[i, j].Symbol = 'K';
                            break;
                        case ' ':
                            fields[i, j] = new Model.EmptyField();
                            fields[i, j].Symbol = ' ';
                            break;
                        case '←':
                            fields[i, j] = new Model.RegularField();
                            fields[i, j].Symbol = '═';
                            break;
                        case '→':
                            fields[i, j] = new Model.RegularField();
                            fields[i, j].Symbol = '═';
                            break;
                        case '↑':
                            fields[i, j] = new Model.RegularField();
                            fields[i, j].Symbol = '║';
                            break;
                        case '↓':
                            fields[i, j] = new Model.RegularField();
                            fields[i, j].Symbol = '║';
                            break;
                        case '█':
                            fields[i, j] = new Model.Warehouse();
                            fields[i, j].Symbol = '█';
                            break;
                        case '◄':
                            fields[i, j] = new Model.RegularField();
                            fields[i, j].Symbol = '~';
                            break;
                        case '╠':
                            fields[i, j] = new Model.SwitchField();
                            fields[i, j].Symbol = '╠';
                            break;
                        case '╣':
                            fields[i, j] = new Model.SwitchField();
                            fields[i, j].Symbol = '╣';
                            break;
                    }
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < characters.Length; j++)
                {
                    Console.Write(fields[i,j].Symbol); 
                }
                Console.WriteLine();
            }

        }
    }
}
