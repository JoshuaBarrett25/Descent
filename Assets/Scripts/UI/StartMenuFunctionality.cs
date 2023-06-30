using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.DefaultInputActions;

public class StartMenuFunctionality : MonoBehaviour
{
    public PlayerStats playerStats;
    public PlayerMovement playerMovement;

    public void CloseStartMenu(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            playerMovement.uiElements[0].SetActive(false);
            playerMovement.uiElements[1].SetActive(true);
            playerMovement.playerActions.Play.Enable();
            playerMovement.playerActions.StartMenu.Disable();
        }
    }

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
