using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_IdleState : IdleState
{
    private Enemy1 enemy1;

    public E1_IdleState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, D_IdleState stateData, Enemy1 enemy1) : base(fsm, enemy, animBoolName, stateData)
    {
        this.enemy1 = enemy1;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange)
        {
            fsm.ChangeState(enemy1.playerDetectedState);
        }

        else if (isIdleTimeOver)
        {
            fsm.ChangeState(enemy1.moveState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
