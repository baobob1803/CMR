using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell 
{
    public int cellX;
    public int cellY;
    public GameObject cellObjectReference;


    public GridCell(int gCellX, int gCellY)
    {
        cellX = gCellX;
        cellY = gCellY;
    }
}
