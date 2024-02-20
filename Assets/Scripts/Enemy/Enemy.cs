using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    public D_Enemy enemyData;

    public int facingDirection {  get; private set; }
    public Rigidbody2D rigid { get; private set; }
    public Animator animator { get; private set; }
    public GameObject GO { get; private set; }
    public PlayerDetection playerDetection { get; private set; }
    public bool facingRight { get; private set; }
    public GameObject parentGO;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;

    private Vector2 velocityWS;

    [Header("Enemy stats")]
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _movementSpeed;


    [Header("Attacking")]
    [SerializeField] private Collider2D _attackBox;

    public virtual void Start()
    {
        facingDirection = 1;

        GO = transform.Find("Alive").gameObject;
        animator = GO.GetComponent<Animator>();
        rigid = GO.GetComponent<Rigidbody2D>();
        playerDetection = GO.GetComponent<PlayerDetection>();

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

    public virtual bool CheckDetection()
    {
        return playerDetection.playerFound;
    }

    public virtual bool CheckPlayerLost()
    {
        return playerDetection.playerLost;
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {

    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {

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
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * enemyData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDistance));
    }
}
