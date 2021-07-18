using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementScript : MonoBehaviour
{
    // component references
    private NavMeshAgent _agent;

    // script references
    [SerializeField]
    internal EnemyScript parentScript;

    // variables
    private int locationIndex = 0; // to which location the enemy's currently going


    // Start is called before the first frame update
    void Start()
    {
        // connecting components & scripts
        _agent = GetComponent<NavMeshAgent>();
        parentScript = GetComponent<EnemyScript>();

        // telling the enemy to move to patrol locations
        MoveToNextPatrolLocation();
    }

    // Update is called once per frame
    void Update()
    {
        // choosing the destination
        if (parentScript.collision.isPlayerDetected == true) // if agent detected the player
            _agent.destination = parentScript.player.position;
        else if (_agent.remainingDistance < 0.2f && !_agent.pathPending) // if agent reached the patrol location
            MoveToNextPatrolLocation();
    }


    // method to tell the enemy to move to the next patrol location
    private void MoveToNextPatrolLocation()
    {
        // making sure that 'parentScript' isn't empty before we assign anything to it
        if (parentScript.locations.Count == 0)
            return;

        // assigning the first location
        _agent.destination = parentScript.locations[locationIndex].position;

        // assigning the second location
        locationIndex = (locationIndex + 1) % parentScript.locations.Count;
        
    }
}
