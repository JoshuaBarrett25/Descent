using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFunctions : MonoBehaviour
{
    [Header("Loading Choice")]
    [SerializeField] private SaveLoading _saveLoading;

    //Objects to load
    [Header("Objects To Load")]
    [SerializeField] private PlayerStats _playerStats;


    private void Start()
    {
        _saveLoading = FindAnyObjectByType<SaveLoading>();
    }

    private void FixedUpdate()
    {
        if (_saveLoading != null)
        {
            if (_saveLoading._isresumeSelected)
            {
                _playerStats.LoadPlayer();
            }
            Debug.Log("Previous save file found");
        }
    }
}
