using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
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
    public GameObject GO { get; private set; }
    public bool facingRight { get; private set; }
    public Collider2D attackBox { get; private set; }
    public AnimationToSM animToStateM { get; private set; }

    [Header("Position Refs")]
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;

    private Vector2 velocityWS;

    public virtual void Start()
    {
        facingDirection = 1;

        GO = transform.Find("Alive").gameObject;
        animator = GO.GetComponent<Animator>();
        rigid = GO.GetComponent<Rigidbody2D>();
        animToStateM = GO.GetComponent<AnimationToSM>();

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
        Debug.Log(facingRight);
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
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
        return Physics2D.Raycast(wallCheck.position, GO.transform.right, enemyData.wallCheckDistance, enemyData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, enemyData.ledgeCheckDistance, enemyData.whatIsGround);
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, GO.transform.right, enemyData.minAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, GO.transform.right, enemyData.maxAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInAttackRange()
    {
        return Physics2D.Raycast(playerCheck.position, GO.transform.right, enemyData.attackDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, GO.transform.right, enemyData.closeRangeActionDistance, enemyData.whatIsPlayer);
    }

    public virtual void Flip(bool lookingAtTarget)
    {

        if (lookingAtTarget)
        {
            
        }

        else
        {
            facingDirection *= -1;
            GO.transform.Rotate(0f, 180f, 0f);
        }
    }

    public virtual void ResetFlip()
    {
        GO.transform.localRotation = Quaternion.identity;
    }

    public virtual void OnDrawGizmos()
    {
        //Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * enemyData.wallCheckDistance));
        //Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDistance));
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + (Vector3)(Vector2.right * facingDirection * enemyData.attackDistance));
    }
}
