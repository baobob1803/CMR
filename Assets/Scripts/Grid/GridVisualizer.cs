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
            GameObject cellObject = GameObject.Instantiate(cellPrefab, new Vector3(iteratedCell.cellX, iteratedCell.cellY, 0), Quaternion.identity);
            cellObject.transform.Rotate(-90, 0, 0, Space.World);
            iteratedCell.cellObjectReference = cellObject;
        }
    }
}
