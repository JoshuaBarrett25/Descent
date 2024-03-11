using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class D_Player : ScriptableObject
{
    [Header("LayerMasks")]
    public LayerMask whatIsSafeArea;
    public LayerMask whatIsGround;
    public LayerMask whatIsWall;

    [Header("Stats")]
    public float health = 3;
    public float stamina = 100;
    public int playerLVL = 1;
    public long currentEXP = 100;
    public long totalEXP = 100;

    [Header("Values")]
    public float gravityScale = 3f;
    public float minJumpingPower = 7;
    public float maxJumpingPower = 17;
    public float speed = 7;
    public float dashSpeed = 11;
    public float diveSpeed = -15;

    [Header("Abilities")]
    public bool DASHACQUIRED;
    public bool DBLJUMPACQUIRED;
    public bool DIVEACQUIRED;

    [Header("Interactions")]
    public DialogueTrigger dialogue;
    public bool interactRange = false;
    public bool canSave = false;

    public float coyoteTime = 0.3f;
    public float jumpInterval = 0.05f;
    public float jumpBufferInterval = 0;
}
