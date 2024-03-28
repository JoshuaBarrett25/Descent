using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class D_Enemy : ScriptableObject
{
    [Header("Enemy stats")]
    public float health = 50;

    public float attackSpeed = 1f;
    public float attackDistance = 0.8f;
    public float attackSize = 2f;
    public float damage = 10;
    public float totalPoise = 100f;
    public float poiseDamage = 20f;
    public float stunnedLength = 2.0f;

    public float movementSpeed = 7f;

    public float wallCheckDistance = 0.5f;
    public float ledgeCheckDistance = 0.6f;
    public float maxAgroDistance = 4f;
    public float minAgroDistance = 3f;

    public float detectionAngle = 45f;

    public float closeRangeActionDistance = 1f;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
