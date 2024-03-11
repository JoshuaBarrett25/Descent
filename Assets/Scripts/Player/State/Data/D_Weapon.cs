using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Weapon Data")]
public class D_Weapon : ScriptableObject
{
    public float attackSize = 3f;
    public float damageValue = 25f;
}
