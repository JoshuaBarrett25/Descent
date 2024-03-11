using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : PlayerState
{
    protected D_DeathState stateData;

    public DeathState(PlayerStateMachine psm, Player player, D_DeathState stateData) : base(psm, player)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

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
