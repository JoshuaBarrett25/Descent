using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private ActionMapManager _actionMapManager;
    [SerializeField] private CameraLookAt _cameraLookAt;

    [Header("Assets")]
    [SerializeField] private TextAsset _inkAsset;

    [Header("Object References")]
    [SerializeField] private GameObject _visualCue;
    [SerializeField] private GameObject _npcLookLocation;

    private bool _playerInRange;

    private void Awake()
    {
        _playerInRange = false;
        _visualCue.SetActive(false);
    }

    private void FixedUpdate()
    {
        _visualCue.SetActive(_playerInRange);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _playerInRange = false;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_playerInRange)
            {
                Debug.Log("Interacted with");
                _actionMapManager.SetActionMap(2);
                _cameraLookAt.SwitchLookAt(_npcLookLocation);
                DialogueManager.GetInstance().EnterDialogueMode(_inkAsset);
            }

        }
    }
}
