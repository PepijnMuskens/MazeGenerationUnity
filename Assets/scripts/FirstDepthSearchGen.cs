using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDepthSearchGen
{
    int currentx = 0;
    int currenty = 0;

    int checkedCells = 1;
    int cellCount;

    int mazeWidth;
    int mazeDepth;
    List<Vector2Int> previousLocations = new List<Vector2Int>();
    
    private MazeCell[,] mazeGrid;

    public FirstDepthSearchGen(MazeCell[,] mazegrid)
    {
        mazeGrid = mazegrid;
        mazeWidth = mazegrid.GetLength(0);
        mazeDepth = mazegrid.GetLength(1);
        cellCount = mazeDepth * mazeWidth;
        currentx = mazegrid.GetLength(0) / 2;
        currenty = mazegrid.GetLength(1) / 2;
        mazeGrid[currentx, currenty].Visit();
        previousLocations.Add(new Vector2Int(currentx, currenty));
    }

    public void GenStep()
    {
        if (checkedCells >= cellCount) { return; }
        bool[] unvisitedNeighbours = giveUnvisitedNeighbours(currentx, currenty);
        int count = 0;
        foreach (bool unvisited in unvisitedNeighbours)
        {
            if (unvisited) count++;
        }
        if (count == 0)
        {
            previousLocations.RemoveAt(previousLocations.Count - 1);
            currentx = previousLocations[previousLocations.Count - 1].x;
            currenty = previousLocations[previousLocations.Count - 1].y;
            GenStep();
        }
        else
        {
            int index = Random.Range(1, count + 1);
            for (int i = 0; i < 4; i++)
            {
                if (unvisitedNeighbours[i] == true)
                {
                    if (index == 1)
                    {
                        nextCellRemoveWalls(currentx, currenty, i);
                        break;
                    }
                    else
                    {
                        index--;
                    }
                }
            }
        }
    }

    bool[] giveUnvisitedNeighbours(int x, int y)
    {
        bool[] cells = new bool[4];

        cells[0] = x != mazeWidth - 1 && !mazeGrid[x + 1, y].Isvisited; //north
        cells[1] = y != mazeDepth - 1 && !mazeGrid[x, y + 1].Isvisited; //east
        cells[2] = x != 0 && !mazeGrid[x - 1, y].Isvisited; //south
        cells[3] = y != 0 && !mazeGrid[x, y - 1].Isvisited; //west
        return cells;
    }

    void nextCellRemoveWalls(int x, int y, int direction)
    {
        switch (direction)
        {
            case 0:
                mazeGrid[currentx, currenty].ClearNorthWall();
                mazeGrid[currentx + 1, currenty].ClearSouthWall();
                currentx++;
                break;
            case 1:
                mazeGrid[currentx, currenty].ClearEastWall();
                mazeGrid[currentx, currenty + 1].ClearWestWall();
                currenty++;
                break;
            case 2:
                mazeGrid[currentx, currenty].ClearSouthWall();
                mazeGrid[currentx - 1, currenty].ClearNorthWall();
                currentx--;
                break;
            case 3:
                mazeGrid[currentx, currenty].ClearWestWall();
                mazeGrid[currentx, currenty - 1].ClearEastWall();
                currenty--;
                break;
            default:
                break;
        }
        previousLocations.Add(new Vector2Int(currentx, currenty));
        mazeGrid[currentx, currenty].Visit();
        checkedCells++;
    }
}
    
