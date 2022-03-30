using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridVisualizer : MonoBehaviour
{
    private static GridVisualizer instanceGV;
    public static GridVisualizer instGridVisualizer {get {return instanceGV;}}

    public GameObject cellPrefab;
    public CellGeneration cellGenerationRef;


    void Awake()
    {
        if(instGridVisualizer != null && instGridVisualizer != this)
        {
            Destroy(this);
        }
        else
        {
            instanceGV = this;
        }
        //This will not create an instance if it's not in the scene
        //Will remove duplicates
        //Accessible anywhere
        //Not kept between scene loads
        //http://gameprogrammingpatterns.com/singleton.html

        cellGenerationRef = GetComponent<CellGeneration>();
    }



    public void VisualizeGrid(BaseGrid gridRef)
    //Create a physical representation of the created grid
    {
        foreach(var iteratedCell in gridRef.listOfGridCells)
        {
            GameObject cellObject = GameObject.Instantiate(cellPrefab, new Vector3(iteratedCell.cellX, iteratedCell.cellY, 0), Quaternion.identity); //Create Physical cell
            cellObject.transform.Rotate(-90, 0, 0, Space.World);
            iteratedCell.cellObjectReference = cellObject;

            //44->46 set cell variables
            cellGenerationRef.listOfAllCells.Add(cellObject);
            cellObject.GetComponent<GameCell>().cellCoordinates.x = iteratedCell.cellX;
            cellObject.GetComponent<GameCell>().cellCoordinates.y = iteratedCell.cellY;
        }

        cellGenerationRef.WallPlacement();
    }
}
