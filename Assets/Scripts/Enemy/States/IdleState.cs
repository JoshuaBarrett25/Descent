using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : State
{
    protected D_IdleState stateData;

    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;

    protected bool isPlayerInMinAgroRange;

    protected float idleTime;

    public IdleState(FiniteStateMachine fsm, Enemy enemy, string animBoolName, D_IdleState stateData) : base(fsm, enemy, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(0f);
        isIdleTimeOver = false;
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        SetRandomIdleTime();
    }
                               
    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            enemy.Flip(false);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Debug.Log("Logic!");
        if (Time.time >= startTime + idleTime)
        {
            Debug.Log("Exiting idle!");
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
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
