using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_MeleeAttackState : ScriptableObject
{
    public float attackRadius = 0.5f;
    public LayerMask whatIsPlayer;
}