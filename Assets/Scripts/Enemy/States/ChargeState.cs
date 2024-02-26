using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
    protected D_ChargeState stateData;

    protected bool isPlayerInAttackRange;
    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;

    protected bool performCloseRangeAction;

    public ChargeState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, D_ChargeState stateData) : base(fsm, enemy, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        isPlayerInAttackRange = enemy.CheckPlayerInAttackRange();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
        performCloseRangeAction = enemy.CheckPlayerInCloseRangeAction();
        enemy.SetVelocity(stateData.chargeSpeed);
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
        isPlayerInAttackRange = enemy.CheckPlayerInAttackRange();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
        performCloseRangeAction = enemy.CheckPlayerInCloseRangeAction();
    }
}
