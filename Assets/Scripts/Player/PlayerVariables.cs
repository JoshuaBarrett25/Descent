using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour, IDataPersistence
{
    [Header("Stats")]
    public float health;
    public float stamina;
    public int playerLVL;
    public long currentEXP;
    public long totalEXP;

    [Header("Values")]
    public float maxJumpingPower;
    public float minJumpingPower;
    public float speed;
    public float dashSpeed;
    public float diveSpeed;

    [Header("Abilities")]
    public bool DASHACQUIRED;
    public bool DBLJUMPACQUIRED;
    public bool DIVEACQUIRED;

    [Header("Interactions")]
    public DialogueTrigger dialogue;
    public bool interactRange = false;
    public bool canSave = false;

    public float coyoteTime;
    public float jumpInterval;
    public float jumpBufferInterval;

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
        this.health = data.health;
        this.stamina = data.stamina;
        this.DASHACQUIRED = data.DASHACQUIRED;
        this.DBLJUMPACQUIRED = data.DBLJUMPACQUIRED;
        this.DIVEACQUIRED = data.DIVEACQUIRED;
    }

    public void SaveData(ref GameData data)
    {        
        data.playerPosition = this.transform.position;
        data.health = this.health;
        data.stamina = this.stamina;
        data.DASHACQUIRED = this.DASHACQUIRED;
        data.DBLJUMPACQUIRED = this.DBLJUMPACQUIRED;
        data.DIVEACQUIRED = this.DIVEACQUIRED;
    }
}