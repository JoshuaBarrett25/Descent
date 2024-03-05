using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Default State Data")]
public class D_DefaultPlayerState : ScriptableObject
{
    public float dblJumpSpace = 0.05f;
    public float dblJumpTimer = 0f;
}
