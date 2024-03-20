using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{

    public FiniteStateMachine stateMachine;

    public D_Enemy enemyData;

    public int facingDirection {  get; private set; }
    public Rigidbody2D rigid { get; private set; }
    public Animator animator { get; private set; }
    public bool facingRight { get; private set; }
    public bool stunned { get; private set; }
    public Transform attackPosition;
    public AnimationToSM animToStateM { get; private set; }

    [Header("Position Refs")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject parent;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;

    private Vector2 velocityWS;
    private float currentPoise;

    public virtual void Start()
    {
        facingDirection = 1;

        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        animToStateM = GetComponent<AnimationToSM>();
        currentPoise = enemyData.totalPoise;

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public void Knockback(AttackDetails attackDetails, bool stun)
    {
        if (stun)
        {
            rigid.velocity.Set(attackDetails.knockBack.x, attackDetails.knockBack.y);
            stunned = true;
        }

        else
        {
            rigid.velocity.Set(attackDetails.knockBack.x, attackDetails.knockBack.y);
        }
    }

    public virtual void Damaged(AttackDetails attackDetails)
    {
        currentPoise -= attackDetails.poiseDamage;
        if (currentPoise > 0)
        {
            enemyData.health -= attackDetails.damageValue;
            Knockback(attackDetails, false);
        }
        if (currentPoise <= 0)
        {
            enemyData.health -= attackDetails.damageValue * 1.2f;
            Knockback(attackDetails, true);
        }
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWS.Set(facingDirection * velocity, rigid.velocity.y);
        rigid.velocity = velocityWS;
    }

    public virtual void ChaseTarget(float velocity)
    {
        velocityWS.Set(velocity, rigid.velocity.y);
        rigid.velocity = velocityWS;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, transform.right, enemyData.wallCheckDistance, enemyData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, enemyData.ledgeCheckDistance, enemyData.whatIsGround);
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, enemyData.minAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, enemyData.maxAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInAttackRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, enemyData.attackDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, enemyData.closeRangeActionDistance, enemyData.whatIsPlayer);
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }

    public virtual void LookAtPlayerDirection()
    {
        if (player.transform.position.x < parent.transform.position.x && facingDirection < -1)
        {
            facingDirection *= -1;
            transform.Rotate(0f, 180f, 0f);
        }

        else if (player.transform.position.x > parent.transform.position.x && facingDirection >= -1)
        {
            facingDirection *= -1;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public virtual void ResetFlip()
    {
        transform.localRotation = Quaternion.identity;
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * enemyData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDistance));
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + (Vector3)(Vector2.right * facingDirection * enemyData.attackDistance));
    }
}
