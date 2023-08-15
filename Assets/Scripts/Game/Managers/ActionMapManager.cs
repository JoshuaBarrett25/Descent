using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionMapManager : MonoBehaviour
{
    public PlayerActions playerActions;
    public PlayerInput playerInput;

    public enum CurrentActionMap
    {
        PLAY, //0
        UI, //1
        DIALOGUE //2
    };

    //Any future action map additions need to go in here to be handled...
    //When switching between current active action map
    private void DisableAll()
    {
        playerActions.PLAY.Disable();
        playerActions.UI.Disable();
        playerActions.DIALOGUE.Disable();
    }

    public void SetActionMap(int MapValue)
    {
        switch (MapValue)
        {
            case (int)CurrentActionMap.PLAY:
                DisableAll();
                playerInput.SwitchCurrentActionMap("PLAY");
                playerActions.PLAY.Enable();
                Debug.Log("Play Action Map is in Action");
                break;

            case (int)CurrentActionMap.UI:
                DisableAll();
                playerInput.SwitchCurrentActionMap("UI");
                playerActions.UI.Enable();
                Debug.Log("UI Action Map is in Action");
                break;

            case (int)CurrentActionMap.DIALOGUE:
                DisableAll();
                playerInput.SwitchCurrentActionMap("DIALOGUE");
                playerActions.DIALOGUE.Enable();
                Debug.Log("Dialogue Action Map is in Action");
                break;
        }

    }

    public string GetActionMap()
    {
        return playerInput.currentActionMap.name;
    }

    private void Update()
    {
        Debug.Log(GetActionMap());
    }
}
