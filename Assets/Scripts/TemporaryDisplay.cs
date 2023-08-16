using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryDisplay : MonoBehaviour
{
    [SerializeField] private float _displayDuration;

    private float _countdown;


    private void Start()
    {
        _countdown = _displayDuration;
    }

    private void FixedUpdate()
    {
        if (this.gameObject.activeSelf)
        {
            _countdown -= Time.deltaTime;
            if (_countdown < 0)
            {
                _countdown = _displayDuration;
                this.gameObject.SetActive(false);
            }
        }
    }
}
