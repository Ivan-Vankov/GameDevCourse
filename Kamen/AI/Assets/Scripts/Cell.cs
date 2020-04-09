using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CellType 
{
    freeSpace = ' ',
    wall = '#',
    path = '*',
    start = 'S',
    goal = 'G'
}
public class Cell : MonoBehaviour
{
    public Cell previous { get; set; }
    public float distanceFromStart = Mathf.Infinity;
    //heurestic value
    public float distanceToGoal { get; set; }
    public float totalDistance()
    {
        return distanceFromStart + distanceToGoal;
    }
    //for making it like a command pattern
    //private Dictionary<CellType, Color> map;
    public CellType cellType=CellType.freeSpace;
 
    void setCellType(CellType c)
    {
        this.cellType = c;
        changeColor();
    }
    void changeColor()
    {
        MeshRenderer gameObjectRenderer = GetComponent<MeshRenderer>();
        Color color;
        // Could use something like command pattern here Map<CellType, Color>
        switch (cellType)
        {
            case CellType.freeSpace: color = Color.white;
                break;
            case CellType.wall: color = Color.black;
                break;
            case CellType.path: color = Color.yellow;
                break;
            case CellType.start: color = Color.green;
                break;
            case CellType.goal: color = Color.green;
                break;
            default:
                //unknown
                color = Color.cyan;
                break;
        }
        gameObjectRenderer.material.SetColor("_Color",color);
    }
    void Update()
    {
        changeColor();   
    }
}
