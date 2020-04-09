using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInitializer : MonoBehaviour
{
    [SerializeField]
    private Object cellPrefab;

    GameObject[,] grid;

    public GameObject[,] createGrid(int width, int height, int goalX, int goalY)
    {
        grid = new GameObject[height,width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                grid[i,j] = (GameObject) Object.Instantiate(cellPrefab, new Vector3(j, i, 0), Quaternion.identity);
            }
        }
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                grid[i, j].GetComponent<Cell>().distanceToGoal = (grid[i, j].transform.position - grid[goalY, goalX].transform.position).magnitude;
            }
        }
        return grid;
    }
}
