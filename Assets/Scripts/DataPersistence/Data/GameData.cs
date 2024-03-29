using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;

    [Header("Stats")]
    public float health;
    public float stamina;

    [Header("Values")]
    public float jumpingPower;
    public float speed;
    public float dashSpeed;
    public float diveSpeed;

    [Header("Abilities")]
    public bool DASHACQUIRED;
    public bool DBLJUMPACQUIRED;
    public bool DIVEACQUIRED;

    public GameData()
    {
        playerPosition = Vector3.zero;
        this.health = 100;
        this.stamina = 100;
        this.DASHACQUIRED = false;
        this.DBLJUMPACQUIRED = false;
        this.DIVEACQUIRED = false;
    }
}
