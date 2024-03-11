using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeState : PlayerState
{
    protected D_SafeState stateData;

    protected bool isPlayerInSafeArea;

    public SafeState(PlayerStateMachine psm, Player player, D_SafeState stateData) : base(psm, player)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        isPlayerInSafeArea = true;


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
