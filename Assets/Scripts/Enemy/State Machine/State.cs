using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class State
{
    protected FiniteStateMachine fsm;
    protected Enemy enemy;

    protected float startTime;

    protected string animBoolName;

    public State(FiniteStateMachine fsm, Enemy enemy, string animBoolName)
    {
        this.fsm = fsm; 
        this.enemy = enemy;
        this.animBoolName = animBoolName;
    }   

    public virtual void Enter()
    {
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
}
