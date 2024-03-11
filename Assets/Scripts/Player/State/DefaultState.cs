using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Basic state for the player character
/// This will be responsible for updating movement, attacking and all player specific controls
/// ALL other states with be handled seperately for example when switching to dialogue controls
/// </summary>


public class DefaultPlayerState : PlayerState
{
    protected D_DefaultPlayerState stateData;


    public DefaultPlayerState(PlayerStateMachine psm, Player player, D_DefaultPlayerState stateData) : base(psm, player)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entering: Default Player State");
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}

