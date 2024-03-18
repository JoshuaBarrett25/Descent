using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : PlayerState
{
    protected D_PlayerCombatState stateData;

    protected bool isInteracting;

    public CombatState(PlayerStateMachine psm, Player player, D_PlayerCombatState stateData) : base(psm, player)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player._playerData.health <= 0)
        {
            psm.ChangeState(player.deathState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
