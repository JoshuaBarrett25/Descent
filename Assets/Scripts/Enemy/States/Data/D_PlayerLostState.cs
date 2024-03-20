using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerLostStateData", menuName = "Data/Enemy State Data/Player Lost Data")]
public class D_PlayerLostState : ScriptableObject
{
    public float idleReturnTimer = 2f;
}