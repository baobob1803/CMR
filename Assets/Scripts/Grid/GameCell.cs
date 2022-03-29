using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell : MonoBehaviour
{
    public Sprite cellSprite;
    public GameObject container;

    [HideInInspector] public Vector2 cellCoordinates;
}
