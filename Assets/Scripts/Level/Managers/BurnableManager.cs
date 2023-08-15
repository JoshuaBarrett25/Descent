using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BurnableManager : MonoBehaviour
{
    [Header("Parent GameObject")]
    [SerializeField] private GameObject _masterGameObject;

    [Header("Base Sprite")]
    [SerializeField] private GameObject _undamagedSprite;

    [Header("Stats")]
    [SerializeField] private float _startingHealth = 100;
    [SerializeField] private float _currentHealth;

    [Header("Damage Mechanic")]
    [SerializeField] public GameObject[] _damagedSprites;
    [SerializeField] private float _staticDamageToObject = 34;
    private bool _isDamaged;

    [Header("Burn Mechanic")]
    [SerializeField] public GameObject[] _burntSprites;
    [SerializeField] public GameObject _activeSprite;
    [SerializeField] private float _burnTimer;
    private float _burnCountdown;
    private float _burnProcesses;
    private int _currentBurnIterations;


    //This section is used for testing and has been made available in inspector
    //Any variables located here are used in the script
    //but can be manually triggered to find faults
    [Header("Testing")]
    [SerializeField] private bool _isBurning;



    private void Start()
    {
        _activeSprite = _undamagedSprite;
        _burnProcesses = (_burnTimer / _burntSprites.Length);
        _burnCountdown = _burnProcesses;
    }

    private void FixedUpdate()
    {
        if(_isBurning)
        {
            _burnCountdown -= Time.deltaTime;
            NextBurnStage(_isDamaged);
        }
    }

    private void NextBurnStage(bool damaged)
    {
        if (_burnCountdown <= 0)
        {
            _currentBurnIterations += 1;

            if (_currentBurnIterations > _burntSprites.Length)
            {
                Destroy(_masterGameObject);
            }

            else if (_currentBurnIterations <= _burntSprites.Length)
            {
                _burnCountdown = _burnProcesses;
                _activeSprite.gameObject.SetActive(false);
                _activeSprite = _burntSprites[_currentBurnIterations - 1];
                _activeSprite.SetActive(true);
            }
        }
    }

    public void TakeDamage()
    {
        _isDamaged = true;
        _currentHealth -= _staticDamageToObject;
        _burnCountdown = _burnCountdown / _currentHealth * 100;

        if (_currentHealth <= 0)
        {
            Destroy(_masterGameObject);
        }
    }
}
