using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGeneration : MonoBehaviour
{

    public Dictionary<int, List<GameCell>> DictOfCellRepartition = new Dictionary<int, List<GameCell>>();
    public List<Vector3> listOfWallsPositions;
    public List<Vector3> listOfEmptyGameCellsPosition;
    public List<Vector3> listOfPGGameCells;


}
