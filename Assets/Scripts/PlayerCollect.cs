using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    [HideInInspector]public bool boosted;


    public void CollisionWithPGDetected(GameObject hitPG)
    {
        Debug.Log("Hit => addscore + destroy");
        Destroy(hitPG);
    }

    public void CollisionWithSPG(GameObject hitSPG)
    {
        Debug.Log("SPG collected");
        Destroy(hitSPG);
    }

}
