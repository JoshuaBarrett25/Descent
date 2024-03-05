using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState currentPlayerState { get; private set; }

    public void Init(PlayerState startingState)
    {
        currentPlayerState = startingState;
        currentPlayerState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        currentPlayerState.Exit();
        currentPlayerState = newState;
        currentPlayerState.Enter();
    }
}
