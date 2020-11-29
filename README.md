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
The given maze input has a height by lines and width element string size, the input is converted into a 2D array or grid in MazeGrid class. 
The elements are calculated with the Height*Width the total size of the 2D array or total elements it contains. A adjacency matrix isnt used to
build edges between each index Node instead it is converted into a binary grid containing 0 and 1 as values/keys. 
Keys are represented as follows; 0 as a wall and 1 as a path. 
