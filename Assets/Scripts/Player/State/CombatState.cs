using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : PlayerState
{
    protected D_CombatState stateData;

    protected bool isPlayerInSafeArea;

    public CombatState(PlayerStateMachine psm, Player player, D_CombatState stateData) : base(psm, player)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        isPlayerInSafeArea = player.CheckSafeArea();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        isPlayerInSafeArea = player.CheckSafeArea();

        if (!isPlayerInSafeArea) 
        {
            
        }
        
        else
        {
            //psm.ChangeState(player.SafeState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
