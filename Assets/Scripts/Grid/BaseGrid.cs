using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGrid 
{
    public int gridHeight;
    public int gridWidth;
    public List<GridCell> listOfGridCells;


    public BaseGrid (int gheight, int gwidth)
    {
        gridHeight = gheight;
        gridWidth = gwidth;
        listOfGridCells = new List<GridCell>();
        GenerateGridCells();
        GridVisualizer.instGridVisualizer.VisualizeGrid(this);
    }


    private void GenerateGridCells()
    // For each coordinates of the grid, a cell is created and added to the list of cells.
    {
        for (int x = 0; x < gridHeight; x++)
        {
            for (int y = 0; y < gridWidth; y++)
            {
                GridCell currentIteratedGridCell = new GridCell(x, y);
                listOfGridCells.Add(currentIteratedGridCell);
            }
        }
    }

}
