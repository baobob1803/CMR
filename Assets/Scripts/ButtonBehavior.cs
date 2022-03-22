using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    public void HighScoreButtonPressed()
    {

    }

    public void OptionButtonPressed()
    {
        
    }
}
