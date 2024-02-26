using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Player
{

    private bool _isFacingRight;
    private bool _isDashing;
    private bool _isJumping;
    private bool _isPreparingJump;
    private bool _isFalling;
    private bool _isDiving;

    private bool _dashed;
    private bool _hasDbljumped;

    private bool _canDBL;

    private float _jumpCooldown;
    private float _timelastOnGround;

    private float variableJumpWS;


    private void Update()
    {
        
    }
}
