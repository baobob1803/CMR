using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour

{
    #region Singleton SafeWay
    private static GameMaster instGameMaster; 
    public static GameMaster instanceGM {get {return instGameMaster;}} 

    public void SingletonCreation()
    {
        if(instGameMaster != null && instGameMaster != this)
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

    public enum GameStates {Init, Playing, GameWon, GameLost}
    public GameStates stateValue;
    private bool gamePaused;
    [HideInInspector] public List<GameObject> listOfCreatedWalls = new List<GameObject>();


    private void Awake()
    {
        SingletonCreation();
        //stateValue = GameStates.Init;
        SwitchOnGameStates(GameStates.Init);
    }


    public void SwitchOnGameStates(GameStates stateValue)
    {
        switch(stateValue)
        {
            case GameStates.Init:
            Debug.Log("Game Setup");
            break;

            case GameStates.Playing:
            Debug.Log("Playing");
            break;
            //States Init & Playing exists if starting screen is needed before launching the game in the game scene

            case GameStates.GameWon:
            ManagePause();
            Debug.Log("win");
            //Spawn UI win 
            break;

            case GameStates.GameLost:
            ManagePause();
            //Spawn UI lose (same UI as win condition but with different parameter)
            break;
        }
    }



















 
    public void ManagePause()
    {
        if(gamePaused)
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
