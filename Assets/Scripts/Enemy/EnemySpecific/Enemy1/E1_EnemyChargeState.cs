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

        if (isPlayerInAttackRange)
        {
            enemy.SetVelocity(0f);
            fsm.ChangeState(enemy1.meleeAttackState);
        }

        if (isDetectingWall || !isDetectingLedge)
        {
            enemy.SetVelocity(0f);
        }

        if (!isDetectingWall || !isDetectingLedge)
        {
            if (!isPlayerInAttackRange)
            {
                if (!isPlayerInDetectionZone)
                {
                    fsm.ChangeState(enemy1.playerLostState);
                }

                else if (isPlayerSeen)
                {
                    Debug.Log("Charging!");
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
