using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Enemy�� �״� ���� ����
public class EnemyDieState : EnemyBaseState
{
    public EnemyDieState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Enemy.Ccollider.enabled = false;
        StartAnimation(stateMachine.Enemy.AnimationData.Dieparameterhash);
        StageManager.Instance.UsedStageAdd(stateMachine.Enemy.gameObject.transform.parent.gameObject);
    }//������ �ִϸ��̼��� �����Ű��, collider�� false�Ͽ� player�� �������� ���ش�.
    // StageManager���� ����� map�� �����ϴ� �Լ��� ����

    private void CheckDieEnd() // �״� �ִϸ��̼��� ������ die�� ����
    {
        AnimatorStateInfo stateinfo = stateMachine.Enemy.Animator.GetCurrentAnimatorStateInfo(0);
        if(stateinfo.normalizedTime >= 1.0f)
        {
            stateMachine.Enemy.Die();
        }
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.Enemy.gameObject.SetActive(true);
        stateMachine.Enemy.gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }// ���� �״� ��Ȳ���� Exit�� ����ȴٴ°��� -> ������ �ϱ� ���� ���� enmey�� �ٽ� idle���·� �ǵ����� exit�� �����
    // ���� �����ִ� object�� collider�� �ٽ� Ȱ��ȭ

    public override void Update()
    {
        base.Update();
        CheckDieEnd();
    }
    
}
