using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class AnimationToSM : MonoBehaviour
{
    public EnemyAttackState attackState;
    public EnemyState enemyState;

    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }

    public void FinishLostAnim()
    {
        enemyState.FinishAnim();
    }
}
