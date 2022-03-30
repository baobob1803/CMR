using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLifeSystem : MonoBehaviour
{
    private Vector3 respawnPoint = new Vector3(10, 10, 0);

    public void KilledByBoostedPlayer()
    {
        transform.position = respawnPoint;
        GetComponent<Ghost>().SwitchOnStates(Ghost.GhostStates.Init);
    }
}
