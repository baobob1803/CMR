using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChase : MonoBehaviour
{
    [HideInInspector] public GameObject playerRef;

    void Awake()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(DetectionLoop());
    }


    private IEnumerator DetectionLoop()
    {
        //Check if he can still detect player (and chase)
        //if not -> switch back to roaming state
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(DetectionLoop());
    }

    public void Selector(int colorIndex)
    {
        switch (colorIndex)
        {

            case 0:
                StartCoroutine(ChasingFirstColor());
                break;

            case 1:
                break;

            case 2:
                break;

            case 3:
                break;
        }

    }



    private IEnumerator ChasingFirstColor()
    {
        //Get player pos
        //Set as destination
        yield return new WaitForSeconds(2f);
    }

    private IEnumerator ChasingSecondColor()
    {
        //Get player pos
        //Find a group of cells around the player pos 
        //Random one of the group as destination
        //Up ghost speed
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator ChasingThirdColor()
    {
        //Get player pos
        //Set all enemies of the map into chasing
        //Go 2-4 cells in front/back of the player
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator ChasingFourthColor()
    {

        yield return new WaitForSeconds(1f);
    }




    public void CoroutineSecurity()
    {
        //Checks all active coroutines to delete or generate some if needed
    }



}
