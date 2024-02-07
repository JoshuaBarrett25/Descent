using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_FollowState : FollowState
{
    private Enemy1 enemy1;

    public E1_FollowState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, D_FollowState stateData, Enemy1 enemy1) : base(fsm, enemy, animBoolName, stateData)
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

        if (enemy.CheckPlayerLost())
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
