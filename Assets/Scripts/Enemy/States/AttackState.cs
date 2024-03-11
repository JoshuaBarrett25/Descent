using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackState : State
{
    protected Transform attackPosition;

    protected bool isAnimationFinished;

    public AttackState(Enemy enemy, FiniteStateMachine fsm,string animBoolName, Transform attackPosition) : base(fsm, enemy, animBoolName)
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
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        //Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position);
    }

    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}
