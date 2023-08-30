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


}
