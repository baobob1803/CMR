using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public enum GhostStates { Init, Roaming, Chasing, Fleeing }

    private GhostChase ghostChaseRef;
    private GhostRoam ghostRoamRef;
    private GhostFlee ghostFleeRef;
    private GhostMovement ghostMovementRef;
    private GhostLifeSystem ghostLifeSystemRef;

    [HideInInspector] public GhostStates ghostGameState;
    public Dictionary<Color, int> DictOfColorTranslation = new Dictionary<Color, int>();
    [HideInInspector] public Color mapColor;

    void Awake()
    {
        RefSetup();
        DictSetup();
    }

    public void RefSetup()
    {
        ghostChaseRef = GetComponent<GhostChase>();
        ghostFleeRef = GetComponent<GhostFlee>();
        ghostRoamRef = GetComponent<GhostRoam>();
        ghostMovementRef = GetComponent<GhostMovement>();
        ghostLifeSystemRef = GetComponent<GhostLifeSystem>();
    }

    public void DictSetup()
    {
        DictOfColorTranslation.Add(Color.red, 0);
        DictOfColorTranslation.Add(Color.yellow, 1);
        DictOfColorTranslation.Add(Color.white, 2);
        DictOfColorTranslation.Add(Color.green, 3);
    }



    public void SwitchOnStates(GhostStates stateToSet)//Launch the right behavior for each ghosts with the color as parameter
    {
        switch (stateToSet)
        {
            case GhostStates.Init:
                SwitchOnStates(GhostStates.Roaming);
                break;

            case GhostStates.Roaming:
                ghostRoamRef.Selector(DictOfColorTranslation[mapColor]);
                break;

            case GhostStates.Chasing:
                ghostChaseRef.Selector(DictOfColorTranslation[mapColor]);
                break;

            case GhostStates.Fleeing:
                ghostFleeRef.Selector(DictOfColorTranslation[mapColor]);
                break;
        }
    }


}
