using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // how long we want the bullet to be seen on the screen
    [SerializeField] private float _onscreenDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // deleting this game object
        Destroy(this.gameObject, _onscreenDelay);
    }
}
