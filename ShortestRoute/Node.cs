using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestRoute
{
    /// <summary>
    /// 
    /// </summary>
    public class Node
    {
        private int i, j;
        public int I { get { return i; } }

        public int J { get { return j; } }

        public int key { get; private set; }

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
    }
}
