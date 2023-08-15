using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class TextFlash : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textObject;
    [SerializeField] private float _flashInterval;
    [SerializeField] private float _offInterval;
    private float _flashTimer;
    private float _offTimer;

    private void Awake()
    {
        _flashTimer = _flashInterval;
        _offTimer = _offInterval;
    }

    private void FixedUpdate()
    {
        if (_flashTimer > 0)
        {
            _flashTimer -= Time.deltaTime;
        }

        if (_flashTimer <= 0)
        {
            _textObject.enabled = false;
            _offTimer -= Time.deltaTime;
            if (_offTimer <= 0)
            {
                _textObject.enabled = true;
                _flashTimer = _flashInterval;
                _offTimer = _offInterval;
            }
        }
    }
}
