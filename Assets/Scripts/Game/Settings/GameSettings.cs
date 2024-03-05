using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class GameSettings : MonoBehaviour
{
    [Header("SystemReferences")]
    [SerializeField] private AudioMixer _gameMixer;
    //[SerializeField] private KeyMapping _keyMap;


    [Header("SoundVariables")]
    public int masterVolume = 100;
    public int musicVolume = 100;
    public int sfxVolume = 100;
    public int dialogueVolume = 100;


    [Header("InputMethodSetupVariables")]
    public float deadzoneX = 0;
    public float deadzoneY = 0;
    

    [Header("AccessibilityVariables")]
    public bool subtitlesActive = true;


    [Header("Global Settings")]
    private bool mouseCursorVisible = false;


    private void Awake()
    {
        Cursor.visible = mouseCursorVisible;
    }
}

