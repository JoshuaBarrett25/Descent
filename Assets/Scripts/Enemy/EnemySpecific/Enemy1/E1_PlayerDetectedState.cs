using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class E1_PlayerDetectedState : PlayerDetectedState
{
    private Enemy1 enemy1;

    private float timerWS;

    public E1_PlayerDetectedState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, D_PlayerDetectedState stateData, Enemy1 enemy1) : base(enemy, fsm, animBoolName, stateData)
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
        timerWS = 0f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerSeen)
        {
            if (timerWS <= stateData.detectionTime)
            {
                timerWS += Time.deltaTime;
            }

            else
            {
                Debug.Log("Switching to charge state");
                fsm.ChangeState(enemy1.chargeState);
            }
        }

        if (!isPlayerSeen)
        {
            Debug.Log("Switching to player lost state");
            fsm.ChangeState(enemy1.playerLostState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
