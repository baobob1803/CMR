using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLifeSystem : MonoBehaviour
{
    private PlayerCollect playerCollectRef;
    public int playerMaxLife;
    public int playerCurrentLife;
    public TextMeshProUGUI lifeDisplayer; //Later use it in a specific visualizer and not the life systems

    void Awake()
    {
        playerCollectRef = GetComponent<PlayerCollect>();
        playerMaxLife = 3;
        playerCurrentLife = playerMaxLife;
        UpdateLife();
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
            UpdateLife();
            Debug.Log("Taking a hit");
        }
        else
        {
            Debug.Log("Losing");
            GameMaster.instanceGM.SwitchOnGameStates(GameMaster.GameStates.GameLost);
            //save highscore w/ json
        }
    }


    public void UpdateLife()
    {
        lifeDisplayer.text = playerCurrentLife.ToString();
    }

}
