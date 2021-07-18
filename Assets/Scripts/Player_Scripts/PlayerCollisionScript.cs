using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    // script references
    [SerializeField]
    internal PlayerScript parentScript;
    private GameBehavior _gameManager;


    // Start is called before the first frame update
    void Start()
    {
        // connecting components
        parentScript = GetComponent<PlayerScript>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    // if enemy's in player's trigged sphere collider
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Enemy")
            Debug.Log("You're detected!"); // notifying
    }

    // if player's not in trigged sphere collider
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Enemy")
            Debug.Log("Enemy out of range, he doesn't see you"); // notifying
    }

    // if enemy has collided with the player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
            _gameManager.HP -= 1; // subtracting one hp
    }


    // if player touches ground
    internal bool IsGrounded()
    {
        // capsule's bottom point
        Vector3 capsuleBottom = new Vector3(parentScript.col.bounds.center.x, parentScript.col.bounds.min.y, parentScript.col.bounds.center.z);
        // checking if capsule touches the "ground"
        bool grounded = Physics.CheckCapsule(parentScript.col.bounds.center, capsuleBottom, parentScript.distanceToGround, parentScript.groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }
}
