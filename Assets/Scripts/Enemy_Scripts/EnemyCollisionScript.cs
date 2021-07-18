using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionScript : MonoBehaviour
{
    // script references
    [SerializeField]
    internal EnemyScript parentScript;

    // variables
    internal bool isPlayerDetected = false; // if the player is in range


    // Start is called before the first frame update
    void Start()
    {
        // connecting scripts
        parentScript = GetComponent<EnemyScript>();
    }

    // if player's in enemy's trigged sphere collider
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            isPlayerDetected = true;
            Debug.Log("Player detected - attack!"); // notifying that player's detected
        }
    }

    // if player's not in trigged sphere collider
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            isPlayerDetected = false;
            Debug.Log("Player out of range, continue patrol"); // notifying that player's not detected
        }
    }
}
