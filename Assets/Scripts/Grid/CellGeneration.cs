using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGeneration : MonoBehaviour
{
    public List<GameObject> listOfAllCells = new List<GameObject>();
    public List<Vector2> listOfWallsPositions;
    public List<Vector2> listOfEmptyGameCellsPosition;
    public List<Vector2> listOfSPGGameCells;
    public GameObject pgPrefab;
    public GameObject wallPrefab;
    public GameObject spgPrefab;



    public void WallPlacement() //Move method to visualizer script
    {
        foreach (var cells in listOfAllCells)
        {
            if (cells.GetComponent<GameCell>().cellCoordinates.x == 0 || cells.GetComponent<GameCell>().cellCoordinates.x == 20 || cells.GetComponent<GameCell>().cellCoordinates.y == 0 || cells.GetComponent<GameCell>().cellCoordinates.y == 20)
            {
                cells.GetComponentInChildren<SpriteRenderer>().color = Color.black;
                listOfWallsPositions.Add(cells.GetComponent<GameCell>().cellCoordinates);
            }

            else
            {
                cells.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
            }
        }

        foreach (var cells in listOfAllCells)
        {
            if (listOfWallsPositions.Contains(cells.GetComponent<GameCell>().cellCoordinates))
            {
                cells.GetComponentInChildren<SpriteRenderer>().color = Color.black;
                var wall = GameObject.Instantiate(wallPrefab, new Vector3(cells.GetComponent<GameCell>().cellCoordinates.x, cells.GetComponent<GameCell>().cellCoordinates.y, -0.03f), Quaternion.identity);
            }
        }
        SetUpPG();
        SetUpSPG();
    }


    public void SetUpPG()
    {
        foreach (var cells in listOfAllCells)
        {
            if (!(listOfWallsPositions.Contains(cells.GetComponent<GameCell>().cellCoordinates) || listOfEmptyGameCellsPosition.Contains(cells.GetComponent<GameCell>().cellCoordinates)))
            {
                var createdPG = GameObject.Instantiate(pgPrefab, new Vector3(cells.GetComponent<GameCell>().cellCoordinates.x, cells.GetComponent<GameCell>().cellCoordinates.y, -0.07f), Quaternion.identity);
                cells.GetComponent<GameCell>().container = createdPG;
            }
        }
    }


    public void SetUpSPG()
    {
        foreach (var cells in listOfAllCells)
        {
            if (listOfSPGGameCells.Contains(cells.GetComponent<GameCell>().cellCoordinates))
            {
                var spawnedSPG = GameObject.Instantiate(spgPrefab, new Vector3(cells.GetComponent<GameCell>().cellCoordinates.x, cells.GetComponent<GameCell>().cellCoordinates.y, -0.07f), Quaternion.identity);
            }
        }
    }



}
