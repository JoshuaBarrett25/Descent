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

        if (enemy.CheckDetection())
        {
            fsm.ChangeState(enemy1.followState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
