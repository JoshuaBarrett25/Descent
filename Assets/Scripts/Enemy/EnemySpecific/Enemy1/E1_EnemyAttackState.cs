using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_EnemyAttackState : EnemyAttackState
{

    public E1_EnemyAttackState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, Transform attackPosition) : base(enemy, fsm, animBoolName, attackPosition)
    {
        
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
