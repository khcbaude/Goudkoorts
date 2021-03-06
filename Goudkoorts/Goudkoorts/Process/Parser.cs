﻿using System;
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


        public List<Model.Field> BuildMaze()
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
            }

            char[] characters = list[0].ToArray();
            Route = new Model.Route();
            Model.Field[,] fields = new Model.Field[list.Count, characters.Length];
            for (int i = 0; i < list.Count; i++)
            {
                characters = list[i].ToArray();
                for (int j = 0; j < characters.Length; j++)
                {
                    switch (characters[j])
                    {
                        case '░':
                            Model.WaterField waterfield = new Model.WaterField('░');
                            fields[i, j] = waterfield;
                            Route.Waterfields.Add(waterfield);
                            break;
                        case 'K':
                            fields[i, j] = new Model.QuayField('K');
                            break;
                        case ' ':
                            fields[i, j] = new Model.EmptyField(' ');
                            break;
                        case '←':
                            fields[i, j] = new Model.RegularField('═');
                            break;
                        case '→':
                            fields[i, j] = new Model.RegularField('═');
                            break;
                        case '↑':
                            fields[i, j] = new Model.RegularField('║');
                            break;
                        case '↓':
                            fields[i, j] = new Model.RegularField('║');
                            break;
                        case '█':
                            Model.Warehouse warehouse = new Model.Warehouse('█');
                            fields[i, j] = warehouse;
                            Route.Warehouses.Add(warehouse);
                            break;
                        case '◄':
                            fields[i, j] = new Model.RegularField('~');
                            break;
                        case '╠':
                            //fields[i, j] = new Model.SwitchField('╠');
                            break;
                        case '╣':
                            //fields[i, j] = new Model.SwitchField('╣');
                            break;
                        case 'x':
                            fields[i, j] = new Model.EndField(' ');
                            break;
                    }
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                characters = list[i].ToArray();
                for (int j = 0; j < characters.Length; j++)
                {
                    switch (characters[j])
                    {  
                        case '╠':
                            Model.SwitchField switchField = new Model.SwitchField('╠');
                            switchField.FirstNext = fields[i, j + 1];
                            switchField.SecondNext = fields[i, j + 1];
                            switchField.FirstPrevious = fields[i - 1, j];
                            switchField.SecondPrevious = fields[i + 1, j];
                            fields[i, j] = switchField;
                            Route.Switches.Add(switchField);
                            break;
                        case '╣':
                            Model.SwitchField switchField2 = new Model.SwitchField('╣');
                            switchField2.FirstNext = fields[i - 1, j];
                            switchField2.SecondNext = fields[i + 1, j];
                            switchField2.FirstPrevious = fields[i, j - 1];
                            switchField2.SecondPrevious = fields[i, j - 1];
                            fields[i, j] = switchField2;
                            Route.Switches.Add(switchField2);
                            break;
                        default:
                            break;
                    }
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                characters = list[i].ToArray();
                for (int j = 0; j < characters.Length; j++)
                {
                    switch (characters[j])
                    {
                        case '←':
                            if (j - 1 > -1)
                            {
                                fields[i, j].Next = fields[i, j - 1];
                            }
                            break;
                        case '→':
                            if (j + 1 < characters.Length)
                            {
                                fields[i, j].Next = fields[i, j + 1];
                            }
                            break;
                        case '░':
                            if (j + 1 < characters.Length)
                            {
                                fields[i, j].Next = fields[i, j + 1];
                            }
                            break;
                        case '█':
                            if (j + 1 < characters.Length)
                            {
                                fields[i, j].Next = fields[i, j + 1];
                            }
                            break;
                        case '↑':
                            if (i - 1 > -1)
                            {
                                fields[i, j].Next = fields[i - 1, j];
                            }
                            break;
                        case '↓':
                            if (i + 1 < list.Count)
                            {
                                fields[i, j].Next = fields[i + 1, j];
                            }
                            break;
                        case 'K':
                            if(j - 1 > -1)
                            {
                                fields[i,j].Next = fields[i,j-1];
                                //Model.WaterField waterField= new Model.WaterField('░');
                                //waterField.Quay = true;
                                //waterField.Next = fields[i - 1, j].Next;
                                //fields[i - 1, j] = waterField;
                                //fields[i - 1, j - 1].Next = fields[i - 1, j];

                            }
                            break;
                        case '◄':
                            if (j - 1 > -1)
                            {
                                fields[i, j].Next = fields[i, j - 1];
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            List<Model.Field> print = new List<Model.Field>();
            for (int i = 0; i < list.Count; i++)
            {
                characters = list[i].ToArray();
                for (int j = 0; j < characters.Length; j++)
                {
                    print.Add(fields[i, j]);
                }
            }
            return print;
        }
    }
}
