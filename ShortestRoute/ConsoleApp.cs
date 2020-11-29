using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShortestRoute
{
    class ConsoleApp
    {
        public static string[] readFile(string path) {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (IOException e) {
                throw new IOException("Could not read file or it does not exist.");
            }
        }

        static void Main(string[] args) {

            while (true) {

                Console.WriteLine("Drag & Drop or Enter the path to Maze '.txt' File:");

                string path = Console.ReadLine();
                string[] a = readFile(path);
                Grid maze = new Grid(a);

                for (int i = 0; i < a.Length; i++) {
                    Console.WriteLine(a[i]);
                }

                Console.WriteLine("The direction is: " + maze.bfSearch());

                Console.WriteLine("Another Maze y or any key ?");
                string inp = Console.ReadLine();
                if (!inp.Equals("y")) {
                    break;
                }
            }

        }
    }
}
