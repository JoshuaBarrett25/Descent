using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected D_EnemyIdleState stateData;

    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;

    protected bool isPlayerSeen;

    protected float idleTime;

    public EnemyIdleState(FiniteStateMachine fsm, Enemy enemy, string animBoolName, D_EnemyIdleState stateData) : base(fsm, enemy, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Checks()
    {
        base.Checks();
        isPlayerSeen = enemy.CheckPlayerSeen();
    }

    public override void Enter()
    {
        base.Enter();
        Checks();
        enemy.SetVelocity(0f);
        isIdleTimeOver = false;
        SetRandomIdleTime();
    }
                               
    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            enemy.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Checks();
    }

    public void SetFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
