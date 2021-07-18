using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionsScript : MonoBehaviour
{
    // script references
    [SerializeField]
    internal PlayerScript parentScript;


    // Start is called before the first frame update
    void Start()
    {
        // connecting components
        parentScript = GetComponent<PlayerScript>();
    }


    // physics-based movement | code
    private void FixedUpdate()
    {
        // rotation variable
        Vector3 rotation = Vector3.up * parentScript.input.hInput; // new "Vector3" variable that'll store our l&r rotation
        Quaternion angleRot = Quaternion.Euler(rotation * Time.deltaTime); // changing our "Vector3" to "Quaternion"

        // actual movement
        parentScript.rb3d.MovePosition(this.transform.position + this.transform.forward * parentScript.input.vInput * Time.deltaTime); // moving
        parentScript.rb3d.MoveRotation(parentScript.rb3d.rotation * angleRot);

        // jumping
        if (parentScript.collision.IsGrounded() && parentScript.input.spacePressed) // if player touches "ground" && space bar is pressed down
            parentScript.rb3d.AddForce(Vector3.up * parentScript.jumpSpeed, ForceMode.Impulse); // adding upward force to jump

        // shooting
        if (parentScript.input.leftHold) // if player holds left mouse button
        {
            // instantiating a new bullet from a prefab 'Bullet'
            GameObject newBullet = Instantiate(parentScript.bullet, this.transform.position + new Vector3(0, 1, 0), this.transform.rotation) as GameObject;
            // connecting a 'Rigidbody' component to the new bullet
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            // assigning the bullet its speed
            bulletRB.velocity = this.transform.forward * parentScript.bulletSpeed;
        }
    }
}
