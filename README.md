# ShortestRoute
Find the shortest route of a maze using BFS.
The .zip contains executable and source code, It is compatible with Any versions of Windows and not supported on MacOS or Linux/Unix systems.
The source code includes unit tests of large methods, the executable is a shortcut from the ~/bin/.exe.

#Example
The console app requires .txt path input, the .txt must contain a consistant format of this example maze;

exp. Maze Input Format
xxxxxxx
xA...Bx
xxxxxxx

Note; The program exits if it detects invalid inputs or formats of the maze.

exp. Maze Ouputs;
EEEE

The keys of the maze given as;
x = walls
. = path
A = start point
B = exit point

#Implementation
The given maze input has a height by lines and width by element length, the input is converted into a 2D array or grid, the MazeGrid class also stores the start and exit node for reference. 
The elements are calculated, (Height x Width) as the total size of the 2D array or total elements it contains. 
An adjacency matrix isnt used to build edges between each index Node instead it is converted into a binary grid containing 0 and 1 as values/keys. 
Keys are represented as follows; 0 as a wall and 1 as a path (including A and B). The binary grid is simple to traverse a directed graph from start node using the adjacencyNode method to get the neighbouring Nodes or Edges for reference the "from" and "to" Nodes. To traverse a Breath-first search algorithm uses queues-FIFO to mark Nodes and its neighbours as visited and add its edges in a list, which is used to backtrack from the exit to start to generate a viable shortest path if a the last "to" node is not equal to exit node then it has a impossible path where A to B is blocked.
The algorithm is simple to implement with the complexity of O(N+E) where N is the number of Nodes and E is the number of Edges, there are also other algorithms which are faster but a lot complex such as A-Star.
