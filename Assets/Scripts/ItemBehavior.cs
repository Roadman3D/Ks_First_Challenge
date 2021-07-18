using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    // storing a reference to 'GameBehavior'
    private GameBehavior _gameManager;

    // prefab to instantiate reference
    [SerializeField] private GameObject _itemPrefab;

    // new item position variables
    [SerializeField] private Vector3 _location1 = new Vector3(10f, 0.125f, -12f);
    [SerializeField] private Vector3 _location2 = new Vector3(-11f, 0.125f, -12f);
    [SerializeField] private Vector3 _location3 = new Vector3(-11f, 0.125f, 12f);


    // Start is called before the first frame update
    void Start()
    {
        // initialising '_gameManager'
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
        // connecting the prefab
        _itemPrefab = GameObject.Find("Item (1)");
    }

    // if something comes in contact with item
    private void OnCollisionEnter(Collision collision)
    {
        // if player came in contact
        if (collision.gameObject.name == "Player")
        {
            // collecting the item
            _gameManager.Item += 1;
            
            // instantiating a new item
            switch (_gameManager.Item)
            {
                case 1:
                    Instantiate(_itemPrefab, _location1, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(_itemPrefab, _location2, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(_itemPrefab, _location3, Quaternion.identity);
                    break;
            }

            // destroying collected item
            Destroy(this.transform.parent.gameObject); // destroying the object
            Debug.Log("Item collected!"); // notifying
        }
    }
}
