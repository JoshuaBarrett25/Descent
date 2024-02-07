    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    protected D_FollowState stateData;
    public FollowState(FiniteStateMachine fsm, Enemy enemy, string animBoolName, D_FollowState stateData) : base(fsm, enemy, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(stateData.followSpeed);
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
