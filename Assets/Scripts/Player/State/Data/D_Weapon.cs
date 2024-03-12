using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Weapon Data")]
public class D_Weapon : ScriptableObject
{
    public float attackSize = 3f;

    public float baseLightAttackDamageValue = 20f;
    public float baseHeavyAttackDamageValue = 50f;

    public float lightAttackCooldown = 0.5f;
    public float heavyAttackCooldown = 1.2f;
}
