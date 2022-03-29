using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneration : MonoBehaviour
{
    public int gridSizeX;
    public int gridSizeY;
    public BaseGrid gridRef;


    void Start()
    {
        gridRef = new BaseGrid(gridSizeX, gridSizeY);
    }


}
