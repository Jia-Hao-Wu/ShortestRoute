using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestRoute;

namespace RouteTesting
{
    [TestClass]
    public class ShortestRouteTest
    {
        public void testMaze(string[] maze, string expected) {
            MazeGrid gridMaze = new MazeGrid(maze);
            List<Edge> edges = Search.bfSearch(gridMaze);
            Assert.AreEqual(Search.shortestPath(edges, gridMaze), expected);
        }

        [TestMethod]
        public void TestShortestRoute1() {
            string[] maze = {
                "xxxxxxxxxx",
                "x........x",
                "x...xx...x",
                "x..Axx.B.x",
                "xxxxxxxxxx"};
            testMaze(maze, "NNEEESSE");
        }

        [TestMethod]
        public void TestShortestRoute2()
        {
            string[] maze = {
                "..........",
                "..........",
                "....xx....",
                "...Axx.B..",
                ".........."};
            testMaze(maze, "SEEENE");
        }

        [TestMethod]
        public void TestShortestRoute3()
        {
            string[] maze = {
                "A.....",
                "......",
                "......",
                ".....B",};
            //shortest path is along the side
            testMaze(maze, "SSSEEEEE");
        }

    }
}
