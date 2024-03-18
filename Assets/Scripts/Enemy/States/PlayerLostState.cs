using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLostState : EnemyState
{
    protected D_PlayerLostState stateData;

    protected bool isPlayerInMaxAgroRange;

    public PlayerLostState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, D_PlayerLostState stateData, Enemy1 enemy1) : base(fsm, enemy, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
