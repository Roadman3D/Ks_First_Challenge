using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{ 
    // ui text variables
    [SerializeField] internal int maxItems = 4;
    internal string labelText = "Collect 4 items and win your freedom!";
    internal string upperText = "WASD = move | space = jump | left mouse click = shoot | if enemy bumps into you, you lose 1 hp | Alt + F4 to close";

    // variables
    private bool _showWinScreen = false; // if the player has won
    private bool _showLossScreen = false; // if the player has lost

    // items collected
    [SerializeField] private int _itemsCollected = 0; // original amount
    // new public variable to access _itemsCollected
    public int Item
    {
        get { return _itemsCollected; } // getting info on items collected
        set {
            _itemsCollected = value; // changing info about items collected
            Debug.Log($"Items: {_itemsCollected}"); // how many items collected?

            // checking number of collected items and notifying the player
            if (_itemsCollected >= maxItems)
            {
                ChangeScreenView("You've found all the items!", true, 0f);
            }
            else
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " left to go!"; // victory not yet
        }
    }

    // player's hp
    [SerializeField] private int _playerHP = 10; // initial amount
    public int HP
    {
        get { return _playerHP; } // getting hp value
        set {
            _playerHP = value; // changing hp value
            Debug.Log($"HP: {_playerHP}"); // how many hp left?

            // if the player has died
            if (_playerHP <= 0)
            {
                ChangeScreenView("You want another life with that?", false, 0f);
            }
            else
                labelText = "Ouch... that's got hurt."; // if the player hasn't died yet
        }
    }
    

    // changing the label text method
    private void ChangeScreenView(string text, bool condition, float pause)
    {
        labelText = text; // changing the label text
        if (condition == true) // if the player won
            _showWinScreen = true;
        else if (condition == false) // if the player lost
            _showLossScreen = true;
        Time.timeScale = pause; // game pause
    }

    // scripting user's graphical interface
    private void OnGUI()
    {
        // standard user interface
        GUI.Box(new Rect(20, 20, 150, 25), "Player health: " + _playerHP); // hp box
        GUI.Box(new Rect(20, 50, 150, 25), "Items collected: " + _itemsCollected); // collected items box
        GUI.Label(new Rect(Screen.width / 2 - 350, Screen.height / 10, 700, 25), upperText); // upper text
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 10 * 9, 300, 25), labelText); // label about what user's left to achieve

        // if the player wins
        if (_showWinScreen)
        {
            // adding a button
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!!!")) // button clicked = true, otherwise false
            {
                // game restart if clicked
                Utilities.RestartLevel(0);
            }
        }

        // adding the loss screen
        if (_showLossScreen)
        {
            // adding a button
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU LOST!")) // button clicked = true, otherwise false
            {
                Utilities.RestartLevel();
            }
        }
    }
}
