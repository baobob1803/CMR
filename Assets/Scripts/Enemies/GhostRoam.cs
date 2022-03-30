using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRoam : MonoBehaviour
{
    

    public void Selector(int colorIndex)
    {
        switch (colorIndex)
        {

            case 0:
                StartCoroutine(RoamingFirstColor());
                break;

            case 1:
                break;

            case 2:
                break;

            case 3:
                break;
        }
    }




    private IEnumerator RoamingFirstColor()
    {
        //Check pos
        //Check if a neighbour cell is free (no walls)
        //if yes, go there
        //if no, find another neighbour
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator RoamingSecondColor()
    {
        //Check pos
        //Find coordinates at least X & Y far from current pos
        //Set destination
        //While not distrupted by player or 
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator RoamingThirdColor()
    {

        yield return new WaitForSeconds(1f);
    }

    private IEnumerator RoamingFourthColor()
    {

        yield return new WaitForSeconds(1f);
    }


    public void CoroutineSecurity()
    {
        //Checks all active coroutines to delete or generate some if needed
    }


}
