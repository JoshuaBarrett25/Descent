using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SavePointHandler : MonoBehaviour
{
    [Header("Display Information")]
    [SerializeField] private GameObject _displayGroup;

    [Header("Player")]
    [SerializeField] private Player _player;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _displayGroup.SetActive(true);
            _player.canSave = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _displayGroup.SetActive(false);
            _player.canSave = false;
        }
    }
}
