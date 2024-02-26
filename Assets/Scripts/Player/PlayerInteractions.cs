using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    public D_Player playerData;

    [Header("Object References")]
    //[SerializeField] private DataPersistenceManager dataPersistenceManager;
    [SerializeField] private ActionMapManager _actionMapManager;

    [Header("UI Elements")]
    [SerializeField] private GameObject _gameSavedText;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            if (playerData.canSave)
            {
                _gameSavedText.gameObject.SetActive(true);
                //dataPersistenceManager.SaveGame();
                //SaveSystem.SavePlayer(_playerStats);
            }


            if (playerData.interactRange)
            {
                Debug.Log("Interacted with");
                _actionMapManager.SetActionMap(2);
                //_playerVariables.dialogue.cameraLookAt.SwitchLookAt(_playerVariables.dialogue.npcLookLocation);
                DialogueManager.GetInstance().EnterDialogueMode(playerData.dialogue.inkAsset);
            }
        }
    }
}
