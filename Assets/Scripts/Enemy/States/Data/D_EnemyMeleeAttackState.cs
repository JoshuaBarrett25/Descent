using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyMeleeAttackStateData", menuName = "Data/Enemy State Data/Melee Attack State")]
public class D_EnemyMeleeAttackState : ScriptableObject
{
    public float attackRadius = 0.5f;
    public float attackDamage = 10f;
    public Vector2 knockback;

    public LayerMask whatIsPlayer;
}
