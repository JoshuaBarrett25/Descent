using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int stamina;
    public int level;
    public float[] position;

    public PlayerData (PlayerStats playerstats)
    {
        health = playerstats.health;
        stamina = playerstats.stamina;
        level = playerstats.level;

        position = new float[3];
        position[0] = playerstats.transform.position.x;
        position[1] = playerstats.transform.position.y;
        position[2] = playerstats.transform.position.z;
    }
}
