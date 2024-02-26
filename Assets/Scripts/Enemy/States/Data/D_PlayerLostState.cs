using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newStateData", menuName = "Data/State Data/Player Lost Data")]
public class D_PlayerLostState : ScriptableObject
{
    public float idleReturnTimer = 0.3f;
}