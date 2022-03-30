using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{

    [HideInInspector] public int nbOfCollectedPG = 0;
    private TextMeshProUGUI scoreRef;

    void Awake()
    {
        scoreRef = GameObject.FindGameObjectWithTag("ScorePanel").GetComponentInChildren<TextMeshProUGUI>();
        UpdateUI();
    }


    public void PGCollection()
    {
        nbOfCollectedPG++;

        UpdateUI();

        if(nbOfCollectedPG == 161)
        {
            GameMaster.instanceGM.SwitchOnGameStates(GameMaster.GameStates.GameWon);
            //Check/Update highscores + json
        }
    }


    public void UpdateUI()
    {
        scoreRef.text = (nbOfCollectedPG*10).ToString();
    }




}
