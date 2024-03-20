using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PlayerLostState : PlayerLostState
{
    protected Enemy1 enemy1;

    protected float timerWS;
    protected float lookTimerInterval;
    protected float lookTimerWS;

    public E1_PlayerLostState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, D_PlayerLostState stateData, Enemy1 enemy1) : base(enemy, fsm, animBoolName, stateData, enemy1)
    {
        this.enemy1 = enemy1;
    }

    public override void Enter()
    {
        base.Enter();
        lookTimerInterval = stateData.idleReturnTimer / 2; 
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

        if (isPlayerInMaxAgroRange)
        {
            timerWS = 0;
            fsm.ChangeState(enemy1.playerDetectedState);
        }

        else if (!isPlayerInMaxAgroRange)
        {
            Debug.Log(lookTimerWS);

            lookTimerWS += Time.deltaTime;
            if (lookTimerWS >= lookTimerInterval)
            {
                lookTimerWS = 0;
                enemy.Flip();
            }
        }
    }

    public override void FinishAnim()
    {
        base.FinishAnim();
        enemy1.idleState.SetFlipAfterIdle(false);
        fsm.ChangeState(enemy1.idleState);
    }
}
