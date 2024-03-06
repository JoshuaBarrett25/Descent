using UnityEngine;
using System.Collections;
using UnityEditor.Timeline;

public class Player : MonoBehaviour
{
    public PlayerStateMachine psm;
    public Map map;

    public bool facingRight { get; private set; }
    public Rigidbody2D rigid { get; private set; }
    public Animator animator { get; private set; }
    public PlayerActions playerActions { get; private set; }

    public DefaultPlayerState defaultPlayerState { get; private set; }

    [Header("State Data Objects")]
    [SerializeField] private D_Player _playerData;
    [SerializeField] private D_DefaultPlayerState _defaultPlayerStateData;

    [Header("Attacking Variables")]
    public Collider2D attackbox;

    [Header("Grounded Variables")]
    public Transform wallCheck;
    public Transform groundCheck;


    public virtual void Start()
    {
        psm = new PlayerStateMachine();
        defaultPlayerState = new DefaultPlayerState(psm, this, _defaultPlayerStateData);
        playerActions = map.playerActions;
        psm.Init(defaultPlayerState);

        
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public virtual bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.05f, _playerData.whatIsGround);
    }

    public virtual bool CheckWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.05f, _playerData.whatIsWall);
    }

    public virtual void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector3 localScale = gameObject.transform.localScale;
        localScale.x *= -1f;
        gameObject.transform.localScale = localScale;
    }

    public virtual void TakeDamage(float calculatedDMG)
    {

    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, 0.05f);
        Gizmos.DrawSphere(wallCheck.position, 0.05f);
    }
}
