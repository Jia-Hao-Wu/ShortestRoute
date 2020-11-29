using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShortestRoute
{
    /// <summary>
    /// Repersents a grid or a 2D g
    /// </summary>
    public class Grid
    {
        private Node[,] grid;

        public readonly int h, w;

        public readonly Node start, exit;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maze"></param>
        public Grid(string[] maze)
        {
            this.h = maze.Length;
            this.w = maze[0].Length;

            Console.WriteLine("height: " + h + "\nwidth: " + w);

            this.grid = new Node[h, w];

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    char mazeChar = maze[i][j];
                    Node cell = new Node(i, j, mazeChar);
                    if (mazeChar.Equals('A'))
                    {
                        start = start == null ? cell : throw new ArgumentException("There are more than one start point");
                    }
                    else if (mazeChar.Equals('B'))
                    {
                        exit = exit == null ? cell : throw new ArgumentException("There are more than one exit point");
                    }
                    this.grid[i, j] = cell;
                }
            }

            if (start == null || exit == null)
            {
                throw new ArgumentException("Invalid Maze. There are no starting and exit points");
            }

        }

        /// <summary>
        /// Edge class to define a edge between nodes as well as backtrack from A-B
        /// the direction variable to record readable path for console output.
        /// </summary>
        class Edge
        {
            public Node From { get; private set; }

            public Node To { get; private set; }

            public readonly char direction;

            public Edge(Node from, Node to, char direction)
            {
                this.From = from;
                this.To = to;
                this.direction = direction;
            }
        }


        /// <summary>
        /// Get a specified path node on point (i, j) on the main multi-dimensional grid array if its not a path node it
        /// does not return anything or null. try catch returns null if the index (i, j) is out of bounds.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns> node or null </returns>
        public Node getPathNode(int i, int j)
        {
            try
            {
                return grid[i, j].key == 1 ? grid[i, j] : null;
            }
            catch (IndexOutOfRangeException e)
            {
                return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string bfSearch()
        {
            Queue<Node> queue = new Queue<Node>();

            bool[,] visited = new bool[h, w];


            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    visited[i, j] = false;
                }
            }

            queue.Enqueue(start);
            visited[start.I, start.J] = true;

            while (!(queue.Count == 0))
            {
                Node deQNode = queue.Dequeue();
                Edge[] adjacentN = adjacentNodes(deQNode);

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
                                if (isNodeEqual(n.To, exit)) break;
                            }
                        }
                    }
                }
            }
            return generateShortestPath();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootNode"></param>
        /// <returns></returns>
        private Edge[] adjacentNodes(Node rootNode)
        {
            //direction i, j; north, south, west and east
            int[] directionI = { -1, 1, 0, 0 };
            int[] directionJ = { 0, 0, -1, 1 };
            char[] readableDirection = { 'N', 'S', 'W', 'E' };

            Edge[] adjNode = new Edge[4];
            int i = rootNode.I, j = rootNode.J;
            for (int a = 0; a < 4; a++)
            {
                int newI = i + directionI[a];
                int newJ = j + directionJ[a];

                if (newI < 0 || newJ < 0 || newI >= h || newJ >= w) continue;
                adjNode[a] = new Edge(rootNode, getPathNode(newI, newJ), readableDirection[a]);
            }
            return adjNode;
        }

        private List<Edge> predecessors = new List<Edge>();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string generateShortestPath()
        {
            int pCount = predecessors.Count - 1;
            string shortestRoute = "";
            Node prevNode;
            if (isNodeEqual(exit, predecessors[pCount].To))
            {
                prevNode = predecessors[pCount].To;
            }
            else
            {
                return "No possible routes, from B to A";
            }

            for (int i = predecessors.Count - 1; i >= 0; i--)
            {
                if (isNodeEqual(predecessors[i].To, prevNode))
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
        /// 
        /// </summary>
        /// <param name="nodeA"></param>
        /// <param name="nodeB"></param>
        /// <returns></returns>
        private bool isNodeEqual(Node nodeA, Node nodeB)
        {
            if (nodeA.I == nodeB.I && nodeA.J == nodeB.J) return true;
            return false;
        }
    }
}



