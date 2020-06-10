/*
11. Route Planner [2D array] [Algorithmic thinking] [Graphs] 

As a part of the route planner, the RouteExists method is used as a quick filter if the destination is reachable, before using more computationally intensive procedures for finding the optimal route.

The roads on the map are rasterized and produce a matrix of boolean values - true if the road is present or false if it is not. The roads in the matrix are connected only if the road is immediately left, right, below or above it.

Finish the RouteExists method so that it returns true if the destination is reachable or false if it is not. The fromRow and fromColumn parameters are the starting row and column in the mapMatrix. The toRow and toColumn are the destination row and column in the mapMatrix. The mapMatrix parameter is the above mentioned matrix produced from the map.

For example, the following code should return true since destination is reachable:

bool[,] mapMatrix = {
	{true, false, false},
	{true, true, false},
	{false, true, true}
};

RouteExists(0, 0, 2, 2, mapMatrix);

https://www.testdome.com/d/c-sharp-interview-questions/18

using System;

public class RoutePlanner
{
    public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                      bool[,] mapMatrix)
    {
        throw new NotImplementedException("Waiting to be implemented.");
    }
    
    public static void Main(string[] args)
    {
        bool[,] mapMatrix = {
            {true, false, false},
            {true, true, false},
            {false, true, true}
        };
        
        Console.WriteLine(RouteExists(0, 0, 2, 2, mapMatrix));
    }
}
*/ 

// =============================================================== solution (passes 4/4 tests)

using System;
using System.Collections.Generic;

public class RoutePlanner
{
    public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                      bool[,] mapMatrix)
    {
        if (!mapMatrix[fromRow, fromColumn])
            return false;
        if (fromRow == toRow && fromColumn == toColumn)
            return mapMatrix[toRow, toColumn];
        var mapCopy = (bool[,]) mapMatrix.Clone(); // to keep the original map intact 
        mapCopy[fromRow, fromColumn] = false;
        var toVisit = new Stack<(int,int)>();
        toVisit.Push((fromRow, fromColumn));
        int numberOfRows = mapMatrix.GetUpperBound(0) + 1;
        int numberOfColumns = mapMatrix.GetUpperBound(1) + 1;
        while (toVisit.Count > 0)
        {
            var (currentRow, currentColumn) = toVisit.Pop();
            var neighbors = new[]{
                (currentRow - 1, currentColumn),
                (currentRow, currentColumn - 1),
                (currentRow, currentColumn + 1),
                (currentRow + 1, currentColumn)
            };
            foreach (var neighbor in neighbors)
            {
                if (-1 < neighbor.Item1 && neighbor.Item1 < numberOfRows &&
                    -1 < neighbor.Item2 && neighbor.Item2 < numberOfColumns)
                {
                    if (mapCopy[neighbor.Item1, neighbor.Item2])
                    {
                        if (neighbor.Item1 == toRow && neighbor.Item2 == toColumn) return true;
                        mapCopy[neighbor.Item1, neighbor.Item2] = false;
                        toVisit.Push(neighbor);
                    }
                }
            }
        }
        return false;
    }
    
    public static void Main(string[] args)
    {
        bool[,] mapMatrix = {
            {true, false, false},
            {true, true, false},
            {false, true, true}
        };
        
        Console.WriteLine(RouteExists(0, 0, 2, 2, mapMatrix));
    }
}