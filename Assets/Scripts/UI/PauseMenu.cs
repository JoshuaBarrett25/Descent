using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class PauseMenu : MonoBehaviour
{
    public Player player;
    public ActionMapManager actionMapManager;
    public static bool isPaused;
    public GameObject startMenu;

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isPaused)
            {
                startMenu.SetActive(false);
                isPaused = false;
                //Sets Play to Current Action map
                actionMapManager.SetActionMap(0);
                Debug.Log("Menu Disabled");
                return;
            }

            else if (!isPaused)
            {
                startMenu.SetActive(true);
                isPaused = true;
                //Sets UI to Current Action map
                actionMapManager.SetActionMap(1);
                Debug.Log("Menu Enabled");
                return;
            }
        }
    }
}
