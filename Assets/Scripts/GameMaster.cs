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


    private bool gamePaused;

    private void Awake()
    {
        SingletonCreation();
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
