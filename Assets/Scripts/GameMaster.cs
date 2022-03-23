using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    private bool gamePaused;
    public static GameMaster instGameMaster;


    private void Awake()
    {
        instGameMaster = this;
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

        Debug.Log(gamePaused);
    }
}
