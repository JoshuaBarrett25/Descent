using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SavePointHandler : MonoBehaviour
{
    [Header("Display Information")]
    [SerializeField] private GameObject _displayGroup;

    [Header("Player")]
    [SerializeField] private PlayerVariables _playerVariables;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _displayGroup.SetActive(true);
            _playerVariables.canSave = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _displayGroup.SetActive(false);
            _playerVariables.canSave = false;
        }
    }
}
