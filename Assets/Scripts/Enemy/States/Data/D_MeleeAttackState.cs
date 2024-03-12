using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State Data/Melee State")]
public class D_MeleeAttackState : ScriptableObject
{
    public float attackRadius = 0.5f;
    public float attackDamage = 10f;

    public LayerMask whatIsPlayer;
}
