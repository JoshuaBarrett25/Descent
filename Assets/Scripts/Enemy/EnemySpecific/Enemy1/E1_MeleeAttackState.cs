using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MeleeAttackState : MeleeAttackState
{
    private Enemy1 enemy1;

    public E1_MeleeAttackState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, Enemy1 enemy1) : base(enemy, fsm, animBoolName, attackPosition, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
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
