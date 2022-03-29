using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    [HideInInspector]public bool boosted;
    [HideInInspector] public ScoreManager scoreManagerRef;
    public float boostdurationSPG;
    
    void Awake()
    {
        scoreManagerRef = GameMaster.instanceGM.GetComponent<ScoreManager>();
    }

    public void CollisionWithPGDetected(GameObject hitPG)
    {
        scoreManagerRef.PGCollection();
        Debug.Log($"player has collected : " + scoreManagerRef.nbOfCollectedPG + " pg");
        Destroy(hitPG);
    }

    public void CollisionWithSPG(GameObject hitSPG)
    {
        Debug.Log("SPG collected");
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
