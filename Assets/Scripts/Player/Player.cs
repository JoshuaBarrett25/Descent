using UnityEngine;
using System.Collections;
using UnityEditor.Timeline;
using System.Net.Sockets;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public PlayerStateMachine psm;
    public Map map;

    public bool facingRight { get; private set; }
    public Rigidbody2D rigid { get; private set; }
    public Animator animator { get; private set; }
    public PlayerActions playerActions { get; private set; }

    public DefaultPlayerState defaultPlayerState { get; private set; }
    public DialogueState dialogueState { get; private set; }
    public CombatState combatState { get; private set; }
    public DeathState deathState { get; private set; }
    public bool _isCombatEnabled { get; private set; }

    [Header("State Data Objects")]
    public D_Weapon _weaponData;
    public D_Player _playerData;
    [SerializeField] private D_DefaultPlayerState _defaultPlayerStateData;
    [SerializeField] private D_DialogueState _dialogueStateData;
    [SerializeField] private D_CombatState _combatStateData;
    [SerializeField] private D_DeathState _deathStateData;

    [Header("Attacking Variables")]
    public Transform attackbox;

    [Header("Grounded Variables")]
    public Transform wallCheck;
    public Transform groundCheck;

    public bool _isAttacking;

    public virtual void Start()
    {
        psm = new PlayerStateMachine();
        defaultPlayerState = new DefaultPlayerState(psm, this, _defaultPlayerStateData);
        dialogueState = new DialogueState(psm, this, _dialogueStateData);
        combatState = new CombatState(psm, this, _combatStateData);
        deathState = new DeathState(psm, this, _deathStateData);
        playerActions = map.playerActions;
        psm.Init(defaultPlayerState);


        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public virtual bool CheckSafeArea()
    {
        return Physics2D.OverlapCircle(gameObject.transform.position, 1f, _playerData.whatIsSafeArea);
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


    public virtual void Damaged(AttackDetails attack)
    {
       _playerData.health -= attack.damageValue;
       
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, 0.05f);
        Gizmos.DrawSphere(wallCheck.position, 0.05f);
    }
}
