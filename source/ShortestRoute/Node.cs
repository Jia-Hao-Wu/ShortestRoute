using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestRoute
{
    /// <summary>
    /// Repersents each node or index of MazeGrid on point (i, j)
    /// </summary>
    public class Node
    {
        private int i, j;

        /// <summary>
        /// Index i
        /// </summary>
        public int I { get { return i; } }


        /// <summary>
        /// Index j
        /// </summary>
        public int J { get { return j; } }

        /// <summary>
        /// Node value or key
        /// </summary>
        public int key { get; private set; }

        /// <summary>
        /// takes array position (i, j) and specifid Maze char value
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="type"></param>
        public Node(int i, int j, char type)
        {
            this.i = i;
            this.j = j;

            if (type.Equals('x'))
            {
                key = 0;
            }
            else if (type.Equals('.') || type.Equals('A') || type.Equals('B'))
            {
                key = 1;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid Inputs, characters of the maze must be 'x', '.', 'A' or 'B'");
            }
        }

        public Node(int i, int j)
        {
            this.i = i;
            this.j = j;
            this.key = 9;
        }
    }

    /// <summary>
    /// Specifies a edge between nodes for a unweighted directed graph
    /// </summary>
    public class Edge
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
        public Edge(Node from, Node to)
        {
            this.From = from;
            this.To = to;
            this.direction = 'n';
        }
    }
}
