using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    private int nbOfCollectedPG = 0;
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

        if(nbOfCollectedPG == 10)
        {
            GameMaster.instanceGM.SwitchOnGameStates(GameMaster.GameStates.GameWon);
            //GameWon
            //Check/Update highscores
            StartCoroutine(Delay()); //will be replaced in Game Master with enum switch states.
        }
    }


    public void UpdateUI()
    {
        scoreRef.text = nbOfCollectedPG.ToString();
        //Will need to add playerLife
    }


    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }


}
