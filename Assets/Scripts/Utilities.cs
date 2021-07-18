using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilities
{
    // deaths count
    public static int playerDeaths = 0;


    // deaths count method
    public static string UpdateDeathCount(ref int countReference)
    {
        countReference += 1; // adding another death
        return "Next time you'll be at number " + countReference; // returning string to notify
    }

    // level restart method
    public static void RestartLevel()
    {
        // 'SceneManager' loads scene, according to the parameter (starting with zero)
        SceneManager.LoadScene(0); // reloading scene (only one scene, indexed zero)
        Time.timeScale = 1f; // unpause the game

        // stats on deaths
        Debug.Log("Player deaths: " + playerDeaths); // num of deaths before
        string message = UpdateDeathCount(ref playerDeaths); // updating stats
        Debug.Log("Player deaths upd: " + playerDeaths); // outputing stats
    }

    // specific level restart method
    public static bool RestartLevel(int sceneIndex)
    {
        // if scene's index is less than zero/negative
        if (sceneIndex < 0)
        {
            throw new System.ArgumentException("Scene index cannot be negative");
        }

        // loading specific scene
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f; // unpausing
        // overload
        return true;
    }
}
