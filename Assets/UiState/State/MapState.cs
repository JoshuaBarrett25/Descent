using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapState
{
    protected MapManager amm;
    protected Map map;

    protected float startTime;

    public MapState(MapManager amm, Map map)
    {
        this.amm = amm;
        this.map = map;
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
}
