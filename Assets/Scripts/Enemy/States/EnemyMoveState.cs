using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    protected D_EnemyMoveState stateData;

    protected bool isPlayerSeen;
    protected bool isDetectingWall;
    protected bool isDetectingLedge;


    public EnemyMoveState(FiniteStateMachine fsm, Enemy enemy, string animBoolName, D_EnemyMoveState stateData) : base(fsm, enemy, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Checks()
    {
        base.Checks();

        isPlayerSeen = enemy.CheckPlayerSeen();
        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(stateData.movementSpeed);

        Checks();
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
        Checks();
    }
}
