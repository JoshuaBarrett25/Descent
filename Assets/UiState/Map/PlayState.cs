using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : MapState
{
    protected D_PlayState stateData;

    protected bool isPauseActive;

    public PlayState(MapManager amm, Map map, D_PlayState stateData) : base(amm, map)
    {
        this.stateData = stateData;
    }
                                         
    public override void Enter()
    {
        base.Enter();
        //Debug.Log("Entering: Play");
        map.playGroup.SetActive(true);
        map.playerActions.Play.Enable();
    }

    public override void Exit()
    {
        base.Exit();
        map.playGroup.SetActive(false);
        map.playerActions.Play.Disable();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        isPauseActive = map.CheckInPause();

        if (isPauseActive)
        {
            amm.ChangeState(map.pauseState);
        }
    }
}
