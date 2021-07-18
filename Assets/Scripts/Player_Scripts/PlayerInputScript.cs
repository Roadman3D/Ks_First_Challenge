using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    // script reference
    [SerializeField]
    internal PlayerScript parentScript;

    // input-holding variables
    internal float vInput; // vertical axis
    internal float hInput; // horizontal axis
    internal bool spacePressed; // space bar to jump
    internal bool leftHold; // 0 = left mouse button pressed, 1 = right, 2 = middle/scroll | our case: to shoot


    // Start is called before the first frame update
    void Start()
    {
        // connecting components
        parentScript = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // detecting what keys are pressed
        vInput = Input.GetAxis("Vertical") * parentScript.moveSpeed; // forward (+ve value) || backward (-ve value)
        hInput = Input.GetAxis("Horizontal") * parentScript.rotateSpeed; // left (-ve value) || right (+ve value)
        spacePressed = Input.GetKeyDown(KeyCode.Space); // if space bar pressed, then true and you jump
        leftHold = Input.GetMouseButtonDown(0); // if left mouse button pressed, to shoot
    }
}
