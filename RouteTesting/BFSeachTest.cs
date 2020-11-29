using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestRoute;

namespace RouteTesting
{
    /// <summary>
    /// Manual Test of BFS and shortest route
    /// </summary>
    [TestClass]
    public class BFSeachTest
    {
        private List<Edge> bfsTraverse(string[] maze)
        {
            MazeGrid gridMaze = new MazeGrid(maze);
            return Search.bfSearch(gridMaze);
        }

        private void bfsEdgeCount(List<Edge> edges, int expected)
        {
            Assert.AreEqual(edges.Count, expected);
        }

        [TestMethod]
        public void TestingEdgeCount1()
        {
            string[] maze = {
                "xxxxxxxxxx",
                "x........x",
                "x...xx...x",
                "x.A.xx.B.x",
                "xxxxxxxxxx"};

            bfsEdgeCount(bfsTraverse(maze), 17);
        }

        [TestMethod]
        public void TestingEdgeCount2()
        {
            string[] maze = {
                "xxxxxx",
                "x....x",
                "x....x",
                "x.A..x",
                "x....x",
                "xxxxBx"};
            bfsEdgeCount(bfsTraverse(maze), 16);
        }

        [TestMethod]
        public void TestBlockedExit()
        {
            string[] maze = {
                "xxxxxx",
                "x....x",
                "x....x",
                "x.A..x",
                "x...xx",
                "xxxxBx"};
            bfsEdgeCount(bfsTraverse(maze), 14);
        }
    }
}
