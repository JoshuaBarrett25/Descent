using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class MenuOptionsSelected : MonoBehaviour
{
    [Header("EventSystem")]
    [SerializeField] private EventSystem _eventSystem;

    [Header("InputSystem")]
    [SerializeField] private InputSystemUIInputModule _inputSystem;

    [Header("GroupObject")]
    [SerializeField] private GameObject objectGroup;

    [Header("Next Selected")]
    public GameObject newSelected;

    private bool switched = false;


    private void Start()
    {
        objectGroup = this.gameObject;
        switched = true;
    }

    private void FixedUpdate()
    {
        if (switched)
        {
            if (_inputSystem.submit.action.phase == InputActionPhase.Waiting)
            {
                _eventSystem.SetSelectedGameObject(newSelected);
                switched = false;
            }
        }
    }

    public void SetNewSelected(GameObject selected)
    {
        newSelected = selected;
        switched = true;
    }
}
