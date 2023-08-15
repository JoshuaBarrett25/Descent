using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [Header("FadeImage")]
    [SerializeField] private Image _fadeImg;
    [SerializeField] private float _fadeSpeed;

    private float _fadeCountdown;
    private bool fading;

    private void Start()
    {
        _fadeCountdown = _fadeSpeed;
        fading = true;
    }
}
