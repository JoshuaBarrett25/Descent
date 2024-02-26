using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public D_Player playerData;

    public int facingDirection { get; private set; }
    public bool facingRight { get; private set; }
    public Rigidbody2D rigid { get; private set; }
    public Animator animator { get; private set; }
    public GameObject GO { get; private set; }

    [SerializeField] private ActionMapManager actionMapManager;

    [Header("Attacking Variables")]
    [SerializeField] private Collider2D _attackbox;

    [Header("Grounded Variables")]
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private Transform _groundCheck;

    

    private void Start()
    {
        facingDirection = 1;

        GO = transform.Find("Alive").gameObject;
        animator = GO.GetComponent<Animator>();
        rigid = GO.GetComponent<Rigidbody2D>();
    }

    public virtual bool CheckGround()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.05f, playerData.whatIsGround);
    }

    public virtual bool CheckWall()
    {
        return Physics2D.OverlapCircle(_wallCheck.position, 0.05f, playerData.whatIsWall);
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        GO.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_groundCheck.position, 0.05f);
        Gizmos.DrawSphere(_wallCheck.position, 0.05f);
    }
}
