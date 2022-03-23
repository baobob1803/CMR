using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    [HideInInspector]public bool boosted;
    private int collectedPG = 0;

    public int multiplierSPG;
    public float boostdurationSPG;

    public void CollisionWithPGDetected(GameObject hitPG)
    {
        Debug.Log("Hit => addscore + destroy");
        collectedPG++;
        //Call UI update
        Debug.Log($"player has collected : " + collectedPG + " pg");
        Destroy(hitPG);
    }

    public void CollisionWithSPG(GameObject hitSPG)
    {
        Debug.Log("SPG collected");
        collectedPG += multiplierSPG;
        boosted = true;
        StartCoroutine(BoostedBehavior(boostdurationSPG));
        Destroy(hitSPG);
    }


    private IEnumerator BoostedBehavior(float boostedTime)
    {
        yield return new WaitForSeconds(boostedTime);
        boosted = false;
    }

}
