using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TicTacToe
{
    class Program
    {

        public static void Main(string[] args)
        {
            Dictionary<string, string> game = new Dictionary<string, string>()
            {
                {"A1"," "},
                {"A2"," "},
                {"A3"," "},
                {"B1"," "},
                {"B2"," "},
                {"B3"," "},
                {"C1"," "},
                {"C2"," "},
                {"C3"," "}
            };

            List<string> location = game.Keys.ToList();

            Console.WriteLine(location);

            Console.WriteLine("# Jeu du Tic Tac Toe #\n");

            string choice;
            Random random = new Random();

            Display(game);


            
            while (location.Any())
            {
                
                Console.Write("TOUR DU JOUEUR : Quel emplacement choisissez-vous ? ");
                choice = Console.ReadLine();


                for (int i=0; i>=0; i++)
                {
                    if (location.Contains(choice))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Vous vous êtes trompé sur la saisie. Veuillez recommencer : ");
                        break;
                    } 
                }

                /*--------------------   6.2   --------------------*/

                game[choice] = "X";


                /*--------------------   6.3   --------------------*/

                location.Remove(choice);

                Display(game);
                /*--------------------   6.4   --------------------*/

                Console.WriteLine("[IA] Je réfléchis...");


                /*--------------------   6.5   --------------------*/

                System.Threading.Thread.Sleep(1000);


                /*--------------------   6.6   --------------------*/

                int index = random.Next(location.Count);
                string iaChoice = location[index];


                /*--------------------   6.7   --------------------*/

                Console.WriteLine("[IA] Je joue en {0}", iaChoice);


                /*--------------------   6.8   --------------------*/

                game[iaChoice] = "O";


                /*--------------------   6.9   --------------------*/

                location.Remove(iaChoice);

                Display(game);

                if(EndGame(game, choice) == true)
                {
                    Console.WriteLine("C'est gagné pour le joueur !");
                    break;
                }
                else if(EndGame(game, iaChoice) == true)
                {
                    Console.WriteLine("C'est gagné pour l'IA !");
                    break;
                }
                
            }

        }


        public static void Display(Dictionary<string, string> game)
        {
            List<string> lines = new List<string> { "A", "B", "C" };
            List<string> columns = new List<string> { "1", "2", "3" };
            string sep = "   +" + string.Concat(Enumerable.Repeat("---+", 3));

            string coord;

            Console.WriteLine("     {0}   {1}   {2}", columns[0], columns[1], columns[2]);

            
            
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(sep);
                Console.Write(" " + lines[i]);
                for (int j = 0; j < 3; j++)
                {
                    coord = lines[i] + columns[j];
                    Console.Write(" | " + game[coord]);
                }
                Console.Write(" |\n");
            }

            Console.WriteLine(sep);
            
        }

        static bool Count3Marks(Dictionary<string, string> game, string symbole)
        {

            var marksCount = 0;

            List<string> l = new List<string> { "X", "O" };

            foreach (string coord in l)
            {
                if (symbole == coord)
                {
                    marksCount++;
                }
            }

            if (marksCount == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool EndGame(Dictionary<string, string> game, string choice)
        {
            string symbole = game[choice];
            List<string> lines = new List<string> { "A", "B", "C" };
            List<string> columns = new List<string> { "1", "2", "3" };
            string l = choice.Substring(0,1);
            string c = choice.Substring(1,1);


            List<string> line = new List<string>{l + columns[0], l + columns[1], l + columns[2]};

            List<string> col = new List<string> {lines[0] + c, lines[1] + c, lines[2] + c};

            List<string> diag1 = new List<string> { lines[0] + columns[0], lines[1] + columns[1], lines[2] + columns[2] };

            List<string> diag2 = new List<string> { lines[2] + columns[0], lines[1] + columns[1], lines[0] + columns[2] };

            Count3Marks(game, symbole);

            if (symbole == game[line[0]] && symbole == game[line[1]] && symbole == game[line[2]])
            {
                return true;
            }

            return false;
        }


    }
}
