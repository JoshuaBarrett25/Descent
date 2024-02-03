using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    public E1_IdleState idleState {  get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_FollowState followState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_FollowState followStateData;

    public override void Start()
    {
        base.Start();

        moveState = new E1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
        followState = new E1_FollowState(this, stateMachine, "follow", followStateData, this);

        stateMachine.Init(moveState);
    }
}
