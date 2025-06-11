using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//enemy의 idle상태
public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    { 
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        CheckHealth();
    }

    private void CheckHealth() // 체력이 0이하가 되면 죽는 상태로 전이
    {
        if(stateMachine.Enemy.Health < 0)
        {
            stateMachine.ChangeState(stateMachine.dieState);
        }
    }
}
