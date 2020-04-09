using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    GameObject[,] grid;

    public int startX, startY, goalX, goalY, width, height;
    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<GridInitializer>().createGrid(width, height,goalX,goalY);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            aStarAlgorithm();
        } 
    }

    void aStarAlgorithm()
    {
        ISet<KeyValuePair<int, int>> openSet = new HashSet<KeyValuePair<int, int>>();
        ISet<KeyValuePair<int, int>> closedSet = new HashSet<KeyValuePair<int, int>>();

        var start = new KeyValuePair<int, int>(startY, startX);
        getCell(start).distanceFromStart = 0;
        getCell(start).cellType = CellType.start;
        getCell(new KeyValuePair<int, int>(goalY, goalX)).cellType = CellType.goal;
        openSet.Add(start);
        while (openSet.Count!=0)
        {
            KeyValuePair<int, int> currentPair = getSmallestTotalDistanceIn(openSet);
            if(currentPair.Key == goalY && currentPair.Value == goalX)
            {
                Debug.Log("Found shortest path");
                constructPath();
                return;
            }
            closedSet.Add(currentPair);
            openSet.Remove(currentPair);

            Cell currentCell = getCell(currentPair);
            foreach (var neighborPair in getNeighbors(currentPair))
            {
                Cell neighborCell = getCell(neighborPair);
                float tentativeDistanceFromStart = currentCell.distanceFromStart + (currentCell.transform.position - neighborCell.transform.position).magnitude;
                if (tentativeDistanceFromStart < neighborCell.distanceFromStart){

                    // we found a better distance
                    neighborCell.previous = currentCell;
                    neighborCell.distanceFromStart = tentativeDistanceFromStart;
                    if (!closedSet.Contains(neighborPair))
                        openSet.Add(neighborPair); 
                }
            }
        }

        Debug.Log("No path found");
    }

    private void constructPath()
    {
        var current = getCell(new KeyValuePair<int, int>(goalY, goalX));
        
        while(current.cellType!=CellType.start)
        {

            if(current.cellType!=CellType.goal)
                current.cellType = CellType.path;
            current = current.previous;
        }
    }

    //gets the cell corresponding to the position
    Cell getCell(KeyValuePair<int,int> pair)
    {
        return grid[pair.Key, pair.Value].GetComponent<Cell>();
    }
    // returns a set of all neighbors which are walkable
    private ISet<KeyValuePair<int,int>> getNeighbors(KeyValuePair<int,int> cell){
        ISet<KeyValuePair<int,int>> result = new HashSet<KeyValuePair<int,int>>();
        for(int i = cell.Key - 1; i <= cell.Key + 1; i++)
        {
            for (int j = cell.Value-1; j <= cell.Value+1; j++)
            {
                if (i == cell.Key && j == cell.Value)
                    continue;
                KeyValuePair<int, int> current = new KeyValuePair<int, int>(i, j);
                if (isFreeCell(current))
                {
                    result.Add(current);
                }
            }
        }
        return result;
    }
    // checks if the index is in array bounds and is free to walk on
    private bool isFreeCell(KeyValuePair<int, int> cell)
    {
        return cell.Key >= 0 && cell.Value >= 0 && cell.Key < height && cell.Value < width && getCell(cell).cellType != CellType.wall;
    }
    // Returns the node with smallest total distancee in the set
    KeyValuePair<int, int> getSmallestTotalDistanceIn(ISet<KeyValuePair<int, int>> set)
    {
        KeyValuePair<int, int> smallest;
        var defaultValue = default(KeyValuePair<int, int>);
        foreach (var current in set)
        {
           if(!smallest.Equals(defaultValue))
            {
                if(getCell(current).totalDistance() < getCell(smallest).totalDistance())
                {
                    smallest = current;
                }
            }
            else
            {
                smallest = current;
            }
        }
        return smallest;
    }
}
