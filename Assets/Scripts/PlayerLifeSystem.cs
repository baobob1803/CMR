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
            enemyHit.GetComponent<GhostLifeSystem>().KilledByBoostedPlayer();
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
            transform.position = new Vector3(10, 8, 0);
            Debug.Log("Taking a hit");
        }
        else
        {
            Debug.Log("Losing");
            GameMaster.instanceGM.SwitchOnGameStates(GameMaster.GameStates.GameLost);
            //save highscore w/ json
        }
    }


}
