using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShortestRoute
{
    /// <summary>
    /// Repersents a non-generic grid or a 2D array for maze traversal/search
    /// </summary>
    public class MazeGrid
    {
        /// <summary>
        /// this is a binary grid that stores nodes with 0 and 1 as keys, the 0 are obstacles and 1 are paths nodes
        /// </summary>
        private Node[,] grid;

        public readonly int h, w;

        public readonly Node start, exit;

        /// <summary>
        /// takes a given string[] where its size of the array as i, and size of the array element as j
        /// </summary>
        /// <param name="maze"></param>
        public MazeGrid(string[] maze)
        {
            this.h = maze.Length;
            this.w = maze[0].Length;

            for (int c = 0; c < h; c++) { 
                if (maze[c].Length != w) {
                    Console.WriteLine("One more lines in the j are not equal in size");
                    throw new ArgumentException("Unequal width lines");
                }
            }

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
                        if (start == null) start = cell;
                        else {
                            Console.WriteLine("There are multiple starting points");
                            Environment.Exit(0);
                        }

                    }
                    else if (mazeChar.Equals('B'))
                    {
                        if (exit == null) exit = cell;
                        else
                        {
                            Console.WriteLine("There are no multiple exit point");
                            Environment.Exit(0);
                        }
                    }
                    this.grid[i, j] = cell;
                }
            }

            if (start == null || exit == null)
            {
                Console.WriteLine("Invalid Maze. There are no starting and exit points");
                Environment.Exit(0);
            }

            

        }


        /// <summary>
        /// Get a specified path node on point (i, j) from grid, ignores non-path nodes
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns> specific path Node or Null </returns>
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
        /// gets the neighbouring edges of rootNode; top, bottom, left and right.
        /// Will returns null directions if non-path nodes.
        /// </summary>
        /// <param name="rootNode"></param>
        /// <returns> Edge[] </returns>
        public Edge[] adjacentNodes(Node rootNode)
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


        /// <summary>
        /// compare NodeA to NodeB using index (i, j)
        /// </summary>
        /// <param name="nodeA"></param>
        /// <param name="nodeB">B</param>
        /// <returns>true if equals</returns>
        public bool isNodeEqual(Node nodeA, Node nodeB)
        {
            if (nodeA.I == nodeB.I && nodeA.J == nodeB.J 
                && nodeA.key == nodeB.key) return true;
            return false;
        }
    }
}



