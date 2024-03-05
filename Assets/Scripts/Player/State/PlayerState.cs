using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine psm;
    protected Player player;

    public PlayerState(PlayerStateMachine psm, Player player)
    {
        this.psm = psm;
        this.player = player;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void Exit() 
    {
    
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}
