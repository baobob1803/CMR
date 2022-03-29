using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoreSystem : MonoBehaviour
{
    private Collider2D collider2DRef;
    private PlayerCollect playerCollectRef;
    private PlayerLifeSystem playerLifeSystemRef;


    void Awake()
    {
        collider2DRef = GetComponent<Collider2D>();
        playerCollectRef = GetComponent<PlayerCollect>();
        playerLifeSystemRef = GetComponent<PlayerLifeSystem>();
    }


    void OnTriggerEnter2D(Collider2D hitObject)
    {
        var tagToCheck = hitObject.tag;

        switch (tagToCheck)
        {
            case "PG":
            playerCollectRef.CollisionWithPGDetected(hitObject.gameObject);
            break;

            case "SPG":
            playerCollectRef.CollisionWithSPG(hitObject.gameObject);
            break;

            case "Ghost":
            Debug.Log("Ghost");
            playerLifeSystemRef.CheckEncounterStatus(hitObject.gameObject);
            break;

            case "TP":
            Debug.Log("TP hit");
            break;

            default:
            break;
        }
        
    }








    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
