using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShortestRoute
{
    /// <summary>
    /// console I/O UI
    /// </summary>
    public class Search
    {

        /// <summary>
        /// traverses the 2D array, in search of exit node and stops until it has reached the specified node or every node
        /// </summary>
        /// <returns></returns>
        public static List<Edge> bfSearch(MazeGrid maze)
        {
            Queue<Node> queue = new Queue<Node>();
            List<Edge> predecessors = new List<Edge>();
            bool[,] visited = new bool[maze.h, maze.w];


            for (int i = 0; i < maze.h; i++)
            {
                for (int j = 0; j < maze.w; j++)
                {
                    visited[i, j] = false;
                }
            }

            queue.Enqueue(maze.start);
            visited[maze.start.I, maze.start.J] = true;

            while (!(queue.Count == 0))
            {
                Node deQNode = queue.Dequeue();
                Edge[] adjacentN = maze.adjacentNodes(deQNode);

                foreach (Edge n in adjacentN)
                {
                    if (n != null)
                    {
                        if (n.To != null)
                        {

                            if (!visited[n.To.I, n.To.J])
                            {
                                //end early if the exit has already been found
                                queue.Enqueue(n.To);
                                visited[n.To.I, n.To.J] = true;
                                predecessors.Add(n);
                                if (maze.isNodeEqual(n.To, maze.exit)) return predecessors;
                            }
                        }
                    }
                }
            }
            return predecessors;
        }

        /// <summary>
        /// backtracks from exit to start to identify the shortest route with the given Edges
        /// returns invalid message if path is blocked or no edges
        /// </summary>
        /// <param name="predecessors"> list to backtrack</param>
        /// <returns>Shortest route</returns>
        public static string shortestPath(List<Edge> predecessors, MazeGrid maze)
        {
            int pCount = predecessors.Count - 1;
            string shortestRoute = "";
            Node prevNode;
            if (maze.isNodeEqual(maze.exit, predecessors[pCount].To))
            {
                prevNode = predecessors[pCount].To;
            }
            else
            {
                Console.WriteLine("No possible routes, from B to A");
                return "";
            }

            for (int i = predecessors.Count - 1; i >= 0; i--)
            {
                if (maze.isNodeEqual(predecessors[i].To, prevNode))
                {
                    shortestRoute += predecessors[i].direction;
                    prevNode = predecessors[i].From;
                }
            }

            char[] revert = shortestRoute.ToCharArray();
            Array.Reverse(revert);

            return new string(revert);
        }

        /// <summary>
        /// read and returns content of a file
        /// </summary>
        /// <param name="path">given file path</param>
        /// <returns>string[] of each line</returns>
        public static string[] readFile(string path) {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (IOException e) {
                Console.WriteLine("Could not read file or it does not exist.");
                Environment.Exit(0);
                return null;
            }
        }

        static void Main(string[] args) {

            while (true) {

                Console.WriteLine("Drag & Drop or Enter the path to Maze '.txt' File:");

                string path = Console.ReadLine();
                string[] a = readFile(path);
                MazeGrid maze = new MazeGrid(a);

                for (int i = 0; i < a.Length; i++) {
                    Console.WriteLine(a[i]);
                }

                List<Edge> passNodePredecessors = bfSearch(maze);
                Console.WriteLine("The direction is: " + shortestPath(passNodePredecessors, maze));

                Console.WriteLine("Another Maze ? (y) or any key to exit");
                string inp = Console.ReadLine();
                if (!inp.Equals("y")) {
                    break;
                }
            }

        }
    }
}
