using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State
{
    protected D_PlayerDetectedState stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;

    protected bool performCloseRangeAction;

    public PlayerDetectedState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, D_PlayerDetectedState stateData) : base(fsm, enemy, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(0);

        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();

        performCloseRangeAction = enemy.CheckPlayerInCloseRangeAction();
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
        isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
        performCloseRangeAction = enemy.CheckPlayerInCloseRangeAction();
    }
}
