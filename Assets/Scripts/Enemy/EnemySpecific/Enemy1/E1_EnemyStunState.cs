using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class E1_EnemyStunState : EnemyStunState
{
    protected Enemy1 enemy1;
    public E1_EnemyStunState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, D_EnemyStunState stateData, Enemy1 enemy1) : base(fsm, enemy, animBoolName, stateData)
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
        if (isStunned)
        {
            stunRecoveryTimer -= Time.deltaTime;

            if (stunRecoveryTimer < 0)
            {
                isStunned = false;
            }
        }

        else
        {
            fsm.ChangeState(enemy1.playerDetectedState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
