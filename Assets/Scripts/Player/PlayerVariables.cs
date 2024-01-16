using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
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

}
