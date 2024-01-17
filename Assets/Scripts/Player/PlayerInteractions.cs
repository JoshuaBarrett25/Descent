using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Object References")]
    //[SerializeField] private DataPersistenceManager dataPersistenceManager;
    [SerializeField] private PlayerVariables _playerVariables;
    [SerializeField] private ActionMapManager _actionMapManager;

    [Header("UI Elements")]
    [SerializeField] private GameObject _gameSavedText;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            if (_playerVariables.canSave)
            {
                _gameSavedText.gameObject.SetActive(true);
                //dataPersistenceManager.SaveGame();
                //SaveSystem.SavePlayer(_playerStats);
            }


            if (_playerVariables.interactRange)
            {
                Debug.Log("Interacted with");
                _actionMapManager.SetActionMap(2);
                //_playerVariables.dialogue.cameraLookAt.SwitchLookAt(_playerVariables.dialogue.npcLookLocation);
                DialogueManager.GetInstance().EnterDialogueMode(_playerVariables.dialogue.inkAsset);
            }
        }
    }
}
