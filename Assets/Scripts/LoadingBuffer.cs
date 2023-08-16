using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBuffer : MonoBehaviour
{
    [Header("LoadingGroup")]
    [SerializeField] private GameObject _loadingScreenGroup;

    [Header("BufferDuration")]
    [SerializeField] private float bufferTimer;
    [SerializeField] private float timer;

    private void Start()
    {
        SetTimer();
    }

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        else
        {
            _loadingScreenGroup.SetActive(false);
        }
    }

    public void SetTimer()
    {
        timer = bufferTimer;
    }
}
