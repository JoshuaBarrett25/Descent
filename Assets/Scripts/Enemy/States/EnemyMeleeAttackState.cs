using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMeleeAttackState : EnemyAttackState
{
    protected D_EnemyMeleeAttackState stateData;
    protected AttackDetails attackDetails;

    protected bool isPlayerInMaxAgroRange;

    public EnemyMeleeAttackState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, Transform attackPosition, D_EnemyMeleeAttackState stateData) : base(enemy, fsm, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        attackDetails = new AttackDetails();
        attackDetails.damageValue = enemy.enemyData.damage;
        attackDetails.position = enemy.transform.position;
        attackDetails.range = enemy.enemyData.attackSize;
        attackDetails.poiseDamage = enemy.enemyData.poiseDamage;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Checks();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        attackDetails.position = enemy.transform.position;
        Debug.Log("Attack!");
        Collider2D[] detectedColliders = Physics2D.OverlapCircleAll(attackDetails.position, attackDetails.range, stateData.whatIsPlayer);
        
        foreach (Collider2D collider in detectedColliders)
        {
           collider.transform.SendMessage("Damaged", attackDetails);
        }
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        
    }

    public override void Checks()
    {
        base.Checks();
        isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
    }
}
