using UnityEngine;
using System.Collections;
using UnityEditor.Timeline;

public class Player : MonoBehaviour
{
    public PlayerStateMachine psm;
    public Map map;

    public bool _facingRight { get; private set; }
    public Rigidbody2D rigid { get; private set; }
    public Animator animator { get; private set; }
    public PlayerActions playerActions { get; private set; }

    public DefaultPlayerState defaultPlayerState { get; private set; }

    [Header("State Data Objects")]
    [SerializeField] private D_Player playerData;
    [SerializeField] private D_DefaultPlayerState defaultPlayerStateData;

    [Header("Attacking Variables")]
    public Collider2D attackbox;

    [Header("Grounded Variables")]
    public Transform wallCheck;
    public Transform groundCheck;


    public virtual void Start()
    {
        psm = new PlayerStateMachine();
        defaultPlayerState = new DefaultPlayerState(psm, this, defaultPlayerStateData);
        playerActions = map.playerActions;
        psm.Init(defaultPlayerState);

        animator = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    public virtual bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.05f, playerData.whatIsGround);
    }

    public virtual bool CheckWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.05f, playerData.whatIsWall);
    }

    public virtual void FlipPlayer()
    {
        _facingRight = !_facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, 0.05f);
        Gizmos.DrawSphere(wallCheck.position, 0.05f);
    }
}
