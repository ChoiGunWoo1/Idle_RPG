using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//enemy�� idle����
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

    private void CheckHealth() // ü���� 0���ϰ� �Ǹ� �״� ���·� ����
    {
        if(stateMachine.Enemy.Health < 0)
        {
            stateMachine.ChangeState(stateMachine.dieState);
        }
    }
}
