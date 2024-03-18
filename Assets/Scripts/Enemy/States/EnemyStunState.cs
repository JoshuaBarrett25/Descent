using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunState : EnemyState
{
    protected D_EnemyStunState stateData;

    protected bool isStunned = false;

    protected float stunRecoveryTimer;

    public EnemyStunState(FiniteStateMachine fsm, Enemy enemy, string animBoolName, D_EnemyStunState stateData) : base(fsm, enemy, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        stunRecoveryTimer = enemy.enemyData.stunnedLength;
        enemy.rigid.velocity.Set(0f,0f);
        isStunned = true;
        
    }

    public override void Exit()
    {
        base.Exit();
        isStunned = false;
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
