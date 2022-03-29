using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridVisualizer : MonoBehaviour
{
    public static GridVisualizer instGridVisualizer;

    public GameObject cellPrefab;


    void Awake()
    {
        instGridVisualizer = this;
    }



    public void VisualizeGrid(BaseGrid gridRef)
    {
        foreach(var iteratedCell in gridRef.listOfGridCells)
        {
            GameObject cellObject = GameObject.Instantiate(cellPrefab, new Vector3(iteratedCell.cellX, 0, iteratedCell.cellY), Quaternion.identity);
            iteratedCell.cellObjectReference = cellObject;
        }
    }
}
