using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // keeping camera relevant to the player
    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f); // distance the camera will be from the player
    private Transform target; // how camera will move pending upon player


    // Start is called before the first frame update
    void Start()
    {
        // finding the player
        target = GameObject.Find("Player").transform; // player's transform values being passed to camera's
    }

    // we want the camera move *after* the player (which moves in *update*)
    void LateUpdate()
    {
        // camera's position
        this.transform.position = target.TransformPoint(camOffset); // setting position to "target", the updating according the offset
        this.transform.LookAt(target); // updating cam's rotation according "target"
    }
}
