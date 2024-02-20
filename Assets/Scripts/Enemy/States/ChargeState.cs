using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
    protected D_ChargeState stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;

    public ChargeState(FiniteStateMachine fsm, Enemy enemy, string animBoolName, D_ChargeState stateData) : base(fsm, enemy, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();

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
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
    }
}
