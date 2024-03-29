using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_EnemyMeleeAttackState : EnemyMeleeAttackState
{
    private Enemy1 enemy1;

    public E1_EnemyMeleeAttackState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, Transform attackPosition, D_EnemyMeleeAttackState stateData, Enemy1 enemy1) : base(enemy, fsm, animBoolName, attackPosition, stateData)
    {
        this.enemy1 = enemy1;
    }

    public override void Enter()
    {
        base.Enter();
        TriggerAttack();
    } 

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Debug.Log(isAnimationFinished);
        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {
                fsm.ChangeState(enemy1.chargeState);
            }

            else
            {
                fsm.ChangeState(enemy1.playerLostState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
