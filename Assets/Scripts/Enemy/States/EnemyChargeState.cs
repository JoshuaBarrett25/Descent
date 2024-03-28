using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeState : EnemyState
{
    protected D_EnemyChargeState stateData;

    protected bool isPlayerInAttackRange;
    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool isPlayerInDetectionZone;
    protected bool isPlayerSeen;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;

    protected bool performCloseRangeAction;

    public EnemyChargeState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, D_EnemyChargeState stateData) : base(fsm, enemy, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Checks()
    {
        base.Checks();
        isPlayerInAttackRange = enemy.CheckPlayerInAttackRange();
        isPlayerSeen = enemy.CheckPlayerSeen();
        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
        isPlayerInDetectionZone = enemy.CheckPlayerInDetectionRadius();
        performCloseRangeAction = enemy.CheckPlayerInCloseRangeAction();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        Checks();
        enemy.SetVelocity(stateData.chargeSpeed);
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
