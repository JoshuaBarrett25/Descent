using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class EnemyState
{
    protected FiniteStateMachine fsm;
    protected Enemy enemy;

    protected float startTime;

    protected string animBoolName;

    public EnemyState(FiniteStateMachine fsm, Enemy enemy, string animBoolName)
    {
        this.fsm = fsm;
        this.enemy = enemy;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        enemy.animToStateM.enemyState = this;
        startTime = Time.time;
        enemy.animator.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        enemy.animator.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Checks()
    {

    }

    public virtual void FinishAnim()
    {

    }

    public virtual void TriggerAttack()
    {

    }
}
