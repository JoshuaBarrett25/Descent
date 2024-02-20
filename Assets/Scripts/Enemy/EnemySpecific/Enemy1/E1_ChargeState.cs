using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_ChargeState : ChargeState
{
    protected Enemy1 enemy1;

    public E1_ChargeState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, D_ChargeState stateData, Enemy1 enemy1) : base(fsm, enemy, animBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
