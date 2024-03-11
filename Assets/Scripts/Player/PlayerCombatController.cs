using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatController : MonoBehaviour
{ 
    public Player player;
    public AttackDetails attackDetails;

    [SerializeField] private D_Player _playerData;
    [SerializeField] private D_Weapon _weaponData;

    [SerializeField] private bool _combatEnabled;
    
    [SerializeField] private LayerMask _whatIsEnemy;

    private float _damageWS;

    private bool _isLightAttacking;
    private bool _isHeavyAttacking;

    private float _attackCooldownWS;


    private void Start()
    {
        //TODO: Player animator
        attackDetails = new AttackDetails();
        attackDetails.position = player.attackbox.position;
        attackDetails.range = _weaponData.attackSize;
        attackDetails.damageValue = _weaponData.damageValue;
    }

    private void FixedUpdate()
    {
        if (_isLightAttacking)
        {
            _attackCooldownWS += Time.deltaTime;
            if (_attackCooldownWS >= player._weaponData.lightAttackCooldown)
            {
                _isLightAttacking = false;
            }
        }

        if (_isHeavyAttacking)
        {
            _attackCooldownWS += Time.deltaTime;
            if (_attackCooldownWS >= player._weaponData.heavyAttackCooldown)
            {
                _isHeavyAttacking = false;
            }
        }
    }

    public void AttackCooldown(float cooldown)
    {

    }

    public void OnLightAttack(InputAction.CallbackContext context)
    {
        if (context.started && !_isLightAttacking)
        {
            TriggerLightAttack();
        }
    }

    public void OnHeavyAttack(InputAction.CallbackContext context)
    {
        if (context.started && !_isHeavyAttacking)
        {
            TriggerHeavyAttack();
        }
    }
    
    private void TriggerLightAttack()
    {
        _isLightAttacking = true;
        Collider2D[] detectedColliders = Physics2D.OverlapBoxAll(attackDetails.position, new Vector2 (attackDetails.range, attackDetails.range), 0, _whatIsEnemy);

        foreach (Collider2D collider in detectedColliders)
        {
            collider.transform.SendMessage("Damaged", attackDetails);
        }
    }

    private void TriggerHeavyAttack()
    {
        _isHeavyAttacking = true;
        Collider2D[] detectedColliders = Physics2D.OverlapBoxAll(attackDetails.position, new Vector2(attackDetails.range, attackDetails.range), 0, _whatIsEnemy);

        foreach (Collider2D collider in detectedColliders)
        {
            collider.transform.SendMessage("Damaged", attackDetails);
        }

    }

    private void Damaged(AttackDetails attack)
    {
        player.Damaged(attack);
    }
}
