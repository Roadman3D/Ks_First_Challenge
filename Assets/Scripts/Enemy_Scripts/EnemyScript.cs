using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // component references
    [SerializeField]
    internal Transform player;

    // script references
    [SerializeField]
    internal EnemyCollisionScript collision;
    [SerializeField]
    internal EnemyMovementScript movement;

    // patrol route variable
    [SerializeField] internal Transform patrolRoute; // parent object that'll store all locations to patrol
    // making a list of all patrol route locations
    [SerializeField] internal List<Transform> locations; // we'll be storing all locations in a list


    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // connecting components & scripts
        player = GameObject.Find("Player").transform;
        collision = GetComponent<EnemyCollisionScript>();
        movement = GetComponent<EnemyMovementScript>();
    }

    // Start is called before any of the Update methods is called the first time
    private void Start()
    {
        // initialising our patrol route variables
        InitializePatrolRoute();
    }


    // method to initialize patrol route locations
    void InitializePatrolRoute()
    {
        // running a for loop to go through all of the locations
        foreach (Transform child in patrolRoute)
            locations.Add(child);
    }
}
