using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyState
{
    protected D_EnemyDeathState stateData;

    protected bool isHidden;

    public EnemyDeathState(FiniteStateMachine fsm, Enemy enemy, string animBoolName, D_EnemyDeathState stateData) : base(fsm, enemy, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.gameObject.layer = LayerMask.NameToLayer("Default");
        enemy.rigid.gravityScale = 0f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isHidden)
        {
            enemy.rigid.velocity.Set(0, 0.5f);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
