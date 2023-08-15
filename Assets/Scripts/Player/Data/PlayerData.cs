using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int stamina;
    public int level;
    public float[] position;
    public float scale;

    public bool dashAcquired;
    public bool dblJumpAcquired;

    public PlayerData (PlayerStats playerstats)
    {
        //Save player stat variables
        health = playerstats.health;
        stamina = playerstats.stamina;
        level = playerstats.level;

        //Save position to new array
        position = new float[3];
        position[0] = playerstats.transform.position.x;
        position[1] = playerstats.transform.position.y;
        position[2] = playerstats.transform.position.z;
        
        //Save player direction they are facing
        scale = playerstats.transform.localScale.x;

        //Save player abilities
        dashAcquired = playerstats.playerAbilities.DASHACQUIRED;
        dblJumpAcquired = playerstats.playerAbilities.DBLJUMPACQUIRED;


    }
}
