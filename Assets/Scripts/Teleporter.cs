using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter otherTPRef;
    public Vector3 positionToSpawn; //Maybe an error will appear on build with a missing ref => to check

    public void OnTriggerEnter2D(Collider2D collider)
    {
        SendToOtherTP(collider.gameObject);
    }

    public void SendToOtherTP(GameObject objToTp)
    {
        otherTPRef.ReceivedFromOtherTP(objToTp);
    }


    public void ReceivedFromOtherTP(GameObject objToTp)
    {
        objToTp.transform.position = positionToSpawn;
    }




}
