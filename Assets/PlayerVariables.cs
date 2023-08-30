using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour, IDataPersistence
{
    [Header("Stats")]
    public float health = 100;
    public float stamina = 100;
    public int playerLVL = 0;
    public long currentEXP = 0;
    public long totalEXP = 0;

    [Header("Values")]
    public float jumpingPower = 16f;
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


    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
        this.health = data.health;
        this.stamina = data.stamina;
        this.jumpingPower = data.jumpingPower;
        this.speed = data.speed;
        this.dashSpeed = data.dashSpeed;
        this.diveSpeed = data.diveSpeed;
        this.DASHACQUIRED = data.DASHACQUIRED;
        this.DBLJUMPACQUIRED = data.DBLJUMPACQUIRED;
        this.DIVEACQUIRED = data.DIVEACQUIRED;
    }

    public void SaveData(ref GameData data)
    {        
        data.playerPosition = this.transform.position;
        data.health = this.health;
        data.stamina = this.stamina;
        data.jumpingPower = this.jumpingPower;
        data.speed = this.speed;
        data.dashSpeed = this.dashSpeed;
        data.diveSpeed = this.diveSpeed;
        data.DASHACQUIRED = this.DASHACQUIRED;
        data.DBLJUMPACQUIRED = this.DBLJUMPACQUIRED;
        data.DIVEACQUIRED = this.DIVEACQUIRED;
    }
}
