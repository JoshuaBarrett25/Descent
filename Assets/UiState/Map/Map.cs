using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public MapManager amm;

    public PlayerActions playerActions;

    public PlayState playState { get; private set; }
    public PauseState pauseState { get; private set; }

    public Player player;

    [Header("State Data Objects")]
    [SerializeField] private D_Map mapData;
    [SerializeField] private D_PlayState playStateData;
    [SerializeField] private D_PauseState pauseStateData;

    [Header("Group References")]
    [Tooltip("Main group gameobjects used to define what is being shown to the player and what is currently active in the scene")]
    public GameObject playGroup;
    public GameObject pauseMenuGroup;

    public Slider healthBarFill;

    public virtual void Awake()
    {
        playerActions = new PlayerActions();
    }

    public virtual void Start()
    {
        amm = new MapManager();
        playState = new PlayState(amm, this, playStateData);
        pauseState = new PauseState(amm, this, pauseStateData);
        player = FindObjectOfType<Player>();

        amm.Init(playState);
    }

    public virtual void Update()
    {
        amm.currentMapState.LogicUpdate();
    }

    public virtual bool CheckInPlay()
    {
        return playGroup.activeInHierarchy;
    }

    public virtual bool CheckInPause()
    {
        return pauseMenuGroup.activeInHierarchy;
    }
}
