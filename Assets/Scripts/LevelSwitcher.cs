using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{

    public List<GameObject> listOfAllWalls = new List<GameObject>();
    public enum LevelMorph { Red, Yellow, White, Phased }
    private int currentLevelSwitchIndex;
    private float switcherTimer = 10;
    private Coroutine corRef;
    public List<GameObject> listOfAllGhosts  =  new List<GameObject>(); //Later init ghost through code and not inspector in scene

    public void InitSwitcher()
    {
        foreach (var wall in GetComponent<GameMaster>().listOfCreatedWalls)
        {
            listOfAllWalls.Add(wall);
        }
        CorCont();
    }

    public void CorCont() //Method to control the number of coroutines and avoid multiples at the same time
    {
        if (corRef == null)
        {
            corRef = StartCoroutine(LevelColorSwitcher());
        }
        else
        {
            StopCoroutine(corRef);
            corRef = StartCoroutine(LevelColorSwitcher());
        }
    }

    private IEnumerator LevelColorSwitcher() //Coroutine to switch level color and enemy behavior
    {
        switcherTimer = 10;

        RandomNumber();

        SwitchIndexEnum();

        yield return new WaitForSeconds(switcherTimer);
        CorCont();
    }


    public void RandomNumber() //Separate method if complex generation needed
    {
        var randomNumber = Random.Range(0, 4);
        if (randomNumber == currentLevelSwitchIndex)
        {
            switcherTimer -= 3;
        }
        currentLevelSwitchIndex = randomNumber;

        //Debug.Log($"RandomNumberFound" + randomNumber);

        /*
        switch(randomNumber)
        {
            case 0 when !(randomNumber == currentLevelSwitchIndex):
            break;

            case 1 when !(randomNumber == currentLevelSwitchIndex):
            switcherTimer += 5;
            break;

            case 2 when !(randomNumber == currentLevelSwitchIndex):
            switcherTimer += 10;
            break;

            case 3 when !(randomNumber == currentLevelSwitchIndex):
            switcherTimer -= 5;
            break;

            default:
            Debug.Log("Same color found");
            switcherTimer -= 2;
            break;
        }
        */
    }


    public void SwitchIndexEnum()
    {
        switch (currentLevelSwitchIndex)
        {
            case 0:
                SwitchOnLevelMorph(LevelMorph.Red);
                break;

            case 1:
                SwitchOnLevelMorph(LevelMorph.Yellow);
                break;

            case 2:
                SwitchOnLevelMorph(LevelMorph.White);
                break;

            case 3:
                SwitchOnLevelMorph(LevelMorph.Phased);
                break;

            default:
                Debug.Log("C'est la merde");
                break;
        }
    }



    public void SwitchOnLevelMorph(LevelMorph levelMorphToSet)
    {
        switch (levelMorphToSet)
        {
            case LevelMorph.Red:
                SwitchColor(Color.red);
                break;

            case LevelMorph.Yellow:
                SwitchColor(Color.yellow);
                break;

            case LevelMorph.White:
                SwitchColor(Color.white);
                break;

            case LevelMorph.Phased:
                //SpecialCase to set later => set to green for now
                SwitchColor(Color.green);
                break;
        }
    }



    public void SwitchColor(Color colorToSet) //Later create a specific visualizer
    {
        foreach (var walls in listOfAllWalls)
        {
            walls.GetComponent<SpriteRenderer>().color = colorToSet;
        }
        foreach(var ghost in listOfAllGhosts)
        {
            ghost.GetComponent<SpriteRenderer>().color = colorToSet;
        }
    }



}
