using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGeneration : MonoBehaviour
{
    public List<GameObject> listOfAllCells = new List<GameObject>();
    public List<Vector2> listOfWallsPositions;
    public List<Vector2> listOfEmptyGameCellsPosition;
    public List<Vector2> listOfSPGGameCells;

    [Header("Prefab references")]
    public GameObject pgPrefab;
    public GameObject wallPrefab;
    public GameObject spgPrefab;

    private Vector2 iteratedCellCoordinates;
    private Color cellColor;



    public void WallPlacement() //Move parts of the method to a visualizer script
    {
        foreach (var cells in listOfAllCells) //Add exterior walls to list of walls => could be replaced by expanding the existing list manually
        {
            iteratedCellCoordinates = cells.GetComponent<GameCell>().cellCoordinates; //Set ref one time each iteration to limit the program complexity

            if (iteratedCellCoordinates.x == 0 || iteratedCellCoordinates.x == 20 || iteratedCellCoordinates.y == 0 || iteratedCellCoordinates.y == 20) //Set up grid border walls
            {
                listOfWallsPositions.Add(iteratedCellCoordinates);
            }
            else
            {
                cells.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
            }
        }

        foreach (var cells in listOfAllCells) //Set up wall prefabs in level
        {
            iteratedCellCoordinates = cells.GetComponent<GameCell>().cellCoordinates;

            if (listOfWallsPositions.Contains(iteratedCellCoordinates))
            {
                cells.GetComponentInChildren<SpriteRenderer>().color = Color.black;
                var wall = GameObject.Instantiate(wallPrefab, new Vector3(iteratedCellCoordinates.x, iteratedCellCoordinates.y, -0.03f), Quaternion.identity);
                GameMaster.instanceGM.listOfCreatedWalls.Add(wall);//Better to get ref in Awake or doesn't matter with singleton or not linked
            }
        }
        SetUpPG();
        SetUpSPG();
        GameMaster.instanceGM.SwitchOnGameStates(GameMaster.GameStates.Playing);
    }


    public void SetUpPG() //Generates the pg in the level
    {
        foreach (var cells in listOfAllCells)
        {
            iteratedCellCoordinates = cells.GetComponent<GameCell>().cellCoordinates;

            if (!(listOfWallsPositions.Contains(iteratedCellCoordinates) || listOfEmptyGameCellsPosition.Contains(iteratedCellCoordinates)))
            {
                var createdPG = GameObject.Instantiate(pgPrefab, new Vector3(iteratedCellCoordinates.x, iteratedCellCoordinates.y, -0.07f), Quaternion.identity);
                cells.GetComponent<GameCell>().container = createdPG; //Not needed now, maybe to remove later
            }
        }
    }


    public void SetUpSPG() //Generates SPG in chosen spots
    {
        foreach (var cells in listOfAllCells) //Could change references to cell in listOfSPGpositions so that the foreach is only on 4 cells and not 441
        {
            iteratedCellCoordinates = cells.GetComponent<GameCell>().cellCoordinates;

            if (listOfSPGGameCells.Contains(iteratedCellCoordinates))
            {
                var spawnedSPG = GameObject.Instantiate(spgPrefab, new Vector3(iteratedCellCoordinates.x, iteratedCellCoordinates.y, -0.07f), Quaternion.identity);
            }
        }
    }



}
