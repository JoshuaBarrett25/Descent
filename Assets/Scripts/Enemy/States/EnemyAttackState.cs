using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttackState : EnemyState
{
    protected Transform attackPosition;

    protected bool isAnimationFinished;
    protected bool isPlayerSeen;

    public EnemyAttackState(Enemy enemy, FiniteStateMachine fsm,string animBoolName, Transform attackPosition) : base(fsm, enemy, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.animToStateM.attackState = this;
        enemy.SetVelocity(0f);
        isAnimationFinished = false;
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
        Checks();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }

    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }

    public override void Checks()
    {
        base.Checks();
        isPlayerSeen = enemy.CheckPlayerSeen();
    }
}
