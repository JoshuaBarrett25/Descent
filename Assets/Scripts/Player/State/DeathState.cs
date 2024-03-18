using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : PlayerState
{
    protected D_PlayerDeathState stateData;

    public DeathState(PlayerStateMachine psm, Player player, D_PlayerDeathState stateData) : base(psm, player)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        player.playerActions.Play.Disable();
        player.playerActions.PauseMenu.Enable();
        player.gameObject.layer = LayerMask.NameToLayer("Default");
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
