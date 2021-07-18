using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // component references
    internal Rigidbody rb3d; // needed for realistic movement
    internal CapsuleCollider col; // storing our player's capsule collider component

    // script references
    [SerializeField]
    internal PlayerInputScript input;
    [SerializeField]
    internal PlayerActionsScript actions;
    [SerializeField]
    internal PlayerCollisionScript collision;

    // player's variables
    [SerializeField] internal float moveSpeed = 10f;
    [SerializeField] internal float rotateSpeed = 75f;
    [SerializeField] internal float jumpSpeed = 5f;

    // other variables
    [SerializeField] internal float distanceToGround = 0.1f; // for not jumping several times in a row by checking distance to ground
    [SerializeField] internal LayerMask groundLayer; // will be needed for our collider detection
    [SerializeField] internal float bulletSpeed = 100f; // our bullet's speed    
    [SerializeField] internal GameObject bullet; // our bullet object


    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // connecting components & scripts
        rb3d = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        input = GetComponent <PlayerInputScript>();
        actions = GetComponent<PlayerActionsScript>();
        collision = GetComponent<PlayerCollisionScript>();
    }
}
