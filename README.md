# ShortestRoute
Find the shortest route of a maze using BFS.
The .zip contains executable and source code, It is compatible with Any versions of Windows and not supported on MacOS or Linux/Unix systems.
The source code includes unit tests of large methods, the executable is a shortcut from the ~/bin/.exe.

# Example
The console app requires .txt path input, the .txt must contain a consistent format of this example maze;

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

# Implementation
The given maze input has a height by lines and width by element length, the input is converted into a 2D array or grid, the MazeGrid class also stores the start and exit node for reference. 


The elements are calculated, (Height x Width) as the total size of the 2D array or total elements it contains. 
An adjacency matrix isnt used to build edges between each index Node (adjacentNode method handles edges), instead it is converted into a binary grid containing 0 and 1 as values/keys. 
Keys are represented as follows; 0 as a wall and 1 as a path (including A and B). The binary grid is simple to traverse a directed graph from start node using the adjacenctNode method to get the neighbouring Nodes or Edges for reference the "from" and "to" Nodes. 

# Algorithm
To traverse a Breath-first search algorithm uses queues-FIFO to mark Nodes and its neighbours as visited and add its edges in a list, which later used for backtracking from exit Node to the start Node. To generate a viable shortest path the last Node element must be equal to exit node, if else it is marked as a impossible path where A to B is blocked.
The BFS is a simple algorithm similar to DFS, also it is not a difficult implementation with its the complexity of O(N+E) where N is the number of Nodes and E is the number of Edges, there are also other algorithms which are faster but a lot complex to implement such as A-Star which would be overkill for maze traversal. 
The choice BFS over DFS, is because the target goal is not far with the given test examples or restrictions, even though both algorithms are nearly identical.

# Testing
The testing implementation are all manual since automated testing can generate blocked and inconsistent results, the unit tests will focus on the algorithm, shortest path method and MazeGrid class. The algorithm and shortest path are tested using given mazes in string arrays while the MazeGrid class is tested within other tests as it needs to construct a grid before BFS traversal takes place.

# Output of Provided Mazes

1)
xxxxxxx
xA...Bx
xxxxxxx

Actual ouput;
EEEE

2)
xxxxx
x...B
A...x
xxxxx

Actual output;
ENEEE

3)
xxxxxxxxxx
x........x
x..xxxx..x
x..xxxx..x
A..xxxx..B
x..xxxx..x
x........x
x........x
xxxxxxxxxx

Actual output;
ESSEEEEEENNEE

4)
xxxxxxxBxxx
x.........x
x...xxxx..x
x...xxxx..x
x....A....x
x..xx.xx..x
x.........x
x.........x
xxxxxxxxxxx

Actual output;
EEENNNWN
