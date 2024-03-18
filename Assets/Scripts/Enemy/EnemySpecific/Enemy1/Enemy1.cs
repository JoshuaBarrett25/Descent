using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    public E1_EnemyIdleState idleState {  get; private set; }
    public E1_EnemyMoveState moveState { get; private set; }
    public E1_PlayerDetectedState playerDetectedState { get; private set; }
    public E1_EnemyChargeState chargeState { get; private set; }
    public E1_PlayerLostState playerLostState { get; private set; }
    public E1_EnemyMeleeAttackState meleeAttackState { get; private set; }
    public E1_EnemyDeathState deathState { get; private set; }
    public E1_EnemyStunState stunState { get; private set; }

  

    [SerializeField] private D_EnemyIdleState idleStateData;
    [SerializeField] private D_EnemyMoveState moveStateData;
    [SerializeField] private D_PlayerDetectedState playerDetectedStateData;
    [SerializeField] private D_EnemyChargeState chargeStateData;
    [SerializeField] private D_PlayerLostState playerLostStateData;
    [SerializeField] private D_EnemyMeleeAttackState meleeAttackStateData;
    [SerializeField] private D_EnemyStunState stunStateData;
    [SerializeField] private D_EnemyDeathState deathStateData;


    public override void Start()
    {
        base.Start();

        moveState = new E1_EnemyMoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_EnemyIdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetectedState(this, stateMachine, "detected", playerDetectedStateData, this);
        chargeState = new E1_EnemyChargeState(this, stateMachine, "charge", chargeStateData, this);
        playerLostState = new E1_PlayerLostState(this, stateMachine, "lost", playerLostStateData, this);
        meleeAttackState = new E1_EnemyMeleeAttackState(this, stateMachine, "melee", attackPosition, meleeAttackStateData, this);
        stunState = new E1_EnemyStunState(this, stateMachine, "stunned", stunStateData, this);
        deathState = new E1_EnemyDeathState(this, stateMachine, "death", deathStateData, this);

        stateMachine.Init(moveState);
    }
}
