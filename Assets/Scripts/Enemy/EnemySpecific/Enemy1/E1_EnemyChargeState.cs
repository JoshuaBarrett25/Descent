using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_EnemyChargeState : EnemyChargeState
{
    protected Enemy1 enemy1;

    public E1_EnemyChargeState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, D_EnemyChargeState stateData, Enemy1 enemy1) : base(enemy, fsm, animBoolName, stateData)
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
        isPlayerInAttackRange = enemy.CheckPlayerInAttackRange();
        enemy.LookAtPlayerDirection();

        if (isPlayerInAttackRange)
        {
            fsm.ChangeState(enemy1.meleeAttackState);
        }

        //||
        if (isDetectingWall)
        {
            Debug.Log("Detecting wall");
            enemy.SetVelocity(0);
        }

        if (!isDetectingLedge)
        {
            Debug.Log("Detecting Ledge");
            enemy.SetVelocity(0);
        }

        if (!isDetectingWall || !isDetectingLedge)
        {
            if (!isPlayerInAttackRange)
            {
                isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
                if (!isPlayerInMaxAgroRange)
                {
                    fsm.ChangeState(enemy1.playerLostState);
                }

                else if (isPlayerInMinAgroRange)
                {
                    enemy.SetVelocity(stateData.chargeSpeed);
                }
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
