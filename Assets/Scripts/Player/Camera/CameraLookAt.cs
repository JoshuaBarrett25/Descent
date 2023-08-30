using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _playerCamera;
    [SerializeField] private GameObject _playerLookAtLocation;

    [Header("Debug")]
    //Used for developer debugging
    public bool debugging;

    /*
    public void SwitchLookAt(GameObject location)
    {
        if (debugging)
        {
            Debug.Log("Changing to look at: " + location.name);
        }

        _playerCamera.Follow = location.transform;
        _playerCamera.LookAt = location.transform;
    }

    public void SwitchToPlayerLookAt()
    {
        if (debugging)
        {
            Debug.Log("Changing to look at: " + _playerLookAtLocation.name);
        }

        _playerCamera.Follow = _playerLookAtLocation.transform;
        _playerCamera.LookAt = _playerLookAtLocation.transform;
    }
    */
}
