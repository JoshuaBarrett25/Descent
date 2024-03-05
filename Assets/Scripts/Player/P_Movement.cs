using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class P_Movement : MonoBehaviour
{
    public Player player;

    [SerializeField] private D_Player playerData;
    protected Vector2 input;

    private float _jumpCooldown;
    private bool _isJumping;
    private bool _startingJump;
    private float _variableJumpPowerWS;

    private float _timeLastOnGround;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
        player.rigid.gravityScale = playerData.gravityScale;
    }
    private void Awake()
    {
        player.playerActions.Play.Jump.performed += OnJump;
        player.playerActions.Play.DoubleJump.performed += OnDoubleJump;
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (_isJumping && player.CheckGround())
        {
            _isJumping = false;
            player.rigid.gravityScale = playerData.gravityScale;
        }
        OnMove();
    }

    public void OnMove()
    {
        input = player.playerActions.Play.Move.ReadValue<Vector2>();
        player.rigid.velocity = new Vector2(input.x * playerData.speed, input.y);

        if (player.rigid.velocity.x > 0f && !player._facingRight)
        {
            player.FlipPlayer();
        }

        if (player.rigid.velocity.x < 0f && player._facingRight)
        {
            player.FlipPlayer();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && !_isJumping && player.CheckGround())
        {
            _isJumping = true;
        }

        if (context.canceled && _isJumping)
        {
            player.rigid.gravityScale += 0.1f;
        }
    }

    public void OnDoubleJump(InputAction.CallbackContext context)
    {

    }
}
