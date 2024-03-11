using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : PlayerState
{
    protected D_DialogueState stateData;

    public DialogueState(PlayerStateMachine psm, Player player, D_DialogueState stateData) : base(psm, player)
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
