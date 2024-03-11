using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    protected D_MeleeAttackState stateData;
    protected AttackDetails attackDetails;

    public MeleeAttackState(Enemy enemy, FiniteStateMachine fsm, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData) : base(enemy, fsm, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        attackDetails.damageValue = stateData.attackDamage;
        attackDetails.position = enemy.GO.transform.position;
        attackDetails.range = enemy.enemyData.attackDistance;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Collider2D[] detectedColliders = Physics2D.OverlapCircleAll(attackDetails.position, attackDetails.range, stateData.whatIsPlayer);

        foreach (Collider2D collider in detectedColliders)
        {
           collider.transform.SendMessage("Damaged", attackDetails);
        }
    }
}
