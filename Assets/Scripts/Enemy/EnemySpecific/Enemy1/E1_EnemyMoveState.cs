using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_EnemyMoveState : EnemyMoveState
{
    private Enemy1 enemy1;

    public E1_EnemyMoveState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, D_EnemyMoveState stateData, Enemy1 enemy1) : base(fsm, enemy, animBoolName, stateData)
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

        if (isPlayerInMaxAgroRange)
        {
            fsm.ChangeState(enemy1.playerDetectedState);
        }

        else if (isDetectingWall || !isDetectingLedge)
        {
            enemy1.idleState.SetFlipAfterIdle(true);
            fsm.ChangeState(enemy1.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
