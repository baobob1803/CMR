using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeSystem : MonoBehaviour
{
    private PlayerCollect playerCollectRef;
    public int playerMaxLife;
    public int playerCurrentLife;

    void Awake()
    {
        playerCollectRef = GetComponent<PlayerCollect>();
        playerMaxLife = 3;
        playerCurrentLife = playerMaxLife;
    }



    public void CheckEncounterStatus(GameObject enemyHit)
    {
        if(playerCollectRef.boosted)
        {
            //Launch method in enemy to damage him + behavior
        }
        else
        {
            DamagePlayer();
        }
    }



    public void DamagePlayer()
    {
        if (playerCurrentLife > 0)
        {
            playerCurrentLife -= 1;
            Debug.Log("Taking a hit");
        }
        else
        {
            Debug.Log("Losing");
            //Game Lost + save highscore,etc...
        }
    }


}
