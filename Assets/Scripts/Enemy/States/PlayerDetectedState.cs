using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : EnemyState
{
    protected D_PlayerDetectedState stateData;

    protected bool isPlayerSeen;
    protected bool isPlayerInMaxAgroRange;
    protected bool isPlayerInDetectionArea;
    protected bool performCloseRangeAction;

    public PlayerDetectedState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, D_PlayerDetectedState stateData) : base(fsm, enemy, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Checks()
    {
        base.Checks();
        isPlayerSeen = enemy.CheckPlayerSeen();
        isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
        isPlayerInDetectionArea = enemy.CheckPlayerInDetectionRadius();
        performCloseRangeAction = enemy.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(0);
        Checks();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Checks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
