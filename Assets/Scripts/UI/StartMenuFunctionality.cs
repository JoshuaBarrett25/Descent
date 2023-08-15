using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.DefaultInputActions;
using TMPro;

public class StartMenuFunctionality : MonoBehaviour
{
    public PlayerStats playerStats;

    public void SaveAndExit()
    {
        playerStats.SavePlayer();
        Debug.Log("Game Data Saved!");
    }

    public void LoadTest()
    {
        playerStats.LoadPlayer();
        Debug.Log("Game Data Loaded!");
    }
}
