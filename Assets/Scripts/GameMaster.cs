using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour

{
    #region Singleton SafeWay
    private static GameMaster instGameMaster;
    public static GameMaster instanceGM { get { return instGameMaster; } }

    public void SingletonCreation()
    {
        if (instGameMaster != null && instGameMaster != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instGameMaster = this;
        }
        //This will not create an instance if it's not in the scene
        //Will remove duplicates
        //Accessible anywhere
        //Not kept between scene loads
        //http://gameprogrammingpatterns.com/singleton.html
    }

    #endregion

    public enum GameStates { Init, Playing, GameWon, GameLost }
    public GameStates stateValue;
    private bool gamePaused;
    private ScoreManager scoreManagerRef;
    [HideInInspector] public List<GameObject> listOfCreatedWalls = new List<GameObject>();
    public GameObject panelRef;


    private void Awake()
    {
        SingletonCreation();
        //stateValue = GameStates.Init;
        SwitchOnGameStates(GameStates.Init);
        scoreManagerRef = GetComponent<ScoreManager>();
    }


    public void SwitchOnGameStates(GameStates stateValue)
    {
        switch (stateValue)
        {
            case GameStates.Init:
                //Debug.Log("Game Setup");
                break;

            case GameStates.Playing:
                GetComponent<LevelSwitcher>().InitSwitcher();
                //Debug.Log("Playing");
                break;
            //States Init & Playing exists if starting screen is needed before launching the game in the game scene

            case GameStates.GameWon:
                GameFinished("Game Won - GG");
                break;

            case GameStates.GameLost:
                GameFinished("Game Lost - Nice try");
                break;
        }
    }


    public void GameFinished(string textToDisplay)
    {
        //Disable IA

        //var panelRef = GameObject.FindGameObjectWithTag("GameFinishedPanel"); => not working for the set active
        panelRef.SetActive(true);
        var endMessage = panelRef.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        var endScore = panelRef.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        endMessage.text = textToDisplay;
        endScore.text = (scoreManagerRef.nbOfCollectedPG*10).ToString();

        StartCoroutine(Delay());
    }


    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }



    public void ManagePause()
    {
        if (gamePaused)
        {
            Time.timeScale = 1;
            gamePaused = false;
        }
        else
        {
            Time.timeScale = 0;
            gamePaused = true;
        }

        //Debug.Log(gamePaused);
    }
}
