using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

        if(nbOfCollectedPG == 3)
        {
            //GameWon
            //Check/Update highscores
            StartCoroutine(Delay());
        }
    }


    public void UpdateUI()
    {
        scoreRef.text = nbOfCollectedPG.ToString();
    }


    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }


}
