using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMovementData", menuName = "Data/Player Data/Movement Data")]
public class D_Movement : ScriptableObject
{
    public float dblJumpSpace = 0.05f;
    public float dblJumpTimer = 0f;
}
