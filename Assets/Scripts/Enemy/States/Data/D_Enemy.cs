using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Enemy : ScriptableObject
{
    [Header("Enemy stats")]
    public float _health;
    public float _damage;
    public float _movementSpeed;
    public float _attackSpeed;

    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;

    public float attackDistance = 2f;
    public float maxAgroDistance = 4f;
    public float minAgroDistance = 3f;

    public float closeRangeActionDistance = 1f;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
