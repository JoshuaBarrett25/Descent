using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] systems;
    [SerializeField] private GameObject _currentActiveSystem;

    private bool startUp = true;

    enum System
    {
        Play,
        UI,
        Dialogue
    }

    private void Awake()
    {
        //Set Default System To Play
        SetActiveSystem(0);
        startUp = false;
    }

    public void SetActiveSystem(int systemIndex)
    {
        switch (systemIndex)
        {
            case (int)System.Play:
                if (!startUp)
                {
                    DeactivateCurrentSystem();
                }
                systems[(int)System.Play].SetActive(true);
                _currentActiveSystem = systems[(int)System.Play];
                break;

            case (int)System.UI:
                DeactivateCurrentSystem();
                systems[(int)System.UI].SetActive(true);
                _currentActiveSystem = systems[(int)System.UI];
                break;

            case (int)System.Dialogue:
                DeactivateCurrentSystem();
                systems[(int)System.Dialogue].SetActive(true);
                _currentActiveSystem = systems[(int)System.Dialogue];
                break;
        }
    }

    private void DeactivateCurrentSystem()
    {
        _currentActiveSystem.gameObject.SetActive(false);
    }
}
