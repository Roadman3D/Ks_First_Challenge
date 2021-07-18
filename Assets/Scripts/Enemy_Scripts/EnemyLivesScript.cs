using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLivesScript : MonoBehaviour
{
    // variables
    private int _lives = 3; // how much lives enemy's got
    public int EnemyLives
    {
        get { return _lives; } // getting the number of lives enemy has got left
        private set {
            _lives = value; // modifying enemy's hp

            // if enemy has no more lives => death
            if (_lives <= 0)
            {
                Destroy(this.gameObject); // death
                Debug.Log("Enemy down.");
            }
        }
    }

    // bullet hit
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)") // checking if the collided object is the bullet
        {
            EnemyLives -= 1; // if enemy's hit by a bullet
            Debug.Log("Critical hit!");
        }
    }
}
