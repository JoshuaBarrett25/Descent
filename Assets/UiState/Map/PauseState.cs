using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : MapState
{
    protected D_PauseState stateData;

    protected bool isPlayActive;
    public PauseState(MapManager amm, Map map, D_PauseState stateData) : base(amm, map)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entering: Pause");
        map.pauseMenuGroup.SetActive(true);
        map.playerActions.PauseMenu.Enable();
    }

    public override void Exit()
    {
        base.Exit();
        map.pauseMenuGroup.SetActive(false);
        map.playerActions.PauseMenu.Disable();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        isPlayActive = map.CheckInPlay();

        if (isPlayActive)
        {
            amm.ChangeState(map.playState);
        }
    }
}
