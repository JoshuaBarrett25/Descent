using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager
{
    public MapState currentMapState { get; private set; }

    public void Init(MapState startingState)
    {
        currentMapState = startingState;
        currentMapState.Enter();
    }

    public void ChangeState(MapState newState)
    {
        currentMapState.Exit();
        currentMapState = newState;
        currentMapState.Enter();
    }
}
