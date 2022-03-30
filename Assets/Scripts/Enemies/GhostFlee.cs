using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFlee : MonoBehaviour
{



    public void Selector(int colorIndex)
    {
        switch (colorIndex)
        {
            case 0:
                break;

            case 1:
                break;

            case 2:
                break;

            case 3:
                break;
        }

    }


    private IEnumerator FleeingFirstColor()
    {
        //get player pos
        //Calculate coordinates at least X,Y far from player
        //Go there (quickest route possible)
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator FleeingSecondColor()
    {
        //get player pos
        //find coordinates opposed to the player
        //Go there but always at least X distance from the player
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator FleeingThirdColor()
    {
        //Get player pos
        //Stay at X distance of the player
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator FleeingFourthColor()
    {
        yield return new WaitForSeconds(1f);
    }


    public void CoroutineSecurity()
    {
        //Checks all active coroutines to delete or generate some if needed
    }

}
