using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

public class SelectionUI : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private InputSystemUIInputModule _inputSystemUI;
    [SerializeField] private ActionMapManager _actionMapManager;
    
    public GameObject[] startingButtonSelected;
    public GameObject firstChoiceButton;

    enum StartingButton
    {
        Dialogue,
        StartMenu,
        Inventory
    }

    public void SetStartingButton(int buttonIndex)
    {
        switch (buttonIndex) 
        {
            case (int)StartingButton.Dialogue:
                _eventSystem.firstSelectedGameObject = startingButtonSelected[0];
                break;
            case (int)StartingButton.StartMenu:

                break;
            case (int)StartingButton.Inventory:

                break;
        }
    }
}
