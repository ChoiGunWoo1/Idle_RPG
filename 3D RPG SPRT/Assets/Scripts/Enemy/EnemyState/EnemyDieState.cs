using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Enemy가 죽는 상태 정의
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
    }//죽을때 애니메이션을 재생시키고, collider를 false하여 player를 지나가게 해준다.
    // StageManager에서 통과한 map을 저장하는 함수를 수행

    private void CheckDieEnd() // 죽는 애니메이션이 끝나면 die를 실행
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
    }// 만약 죽는 상황에서 Exit가 실행된다는것은 -> 재사용을 하기 위해 죽은 enmey를 다시 idle상태로 되돌릴때 exit가 실행됨
    // 따라서 꺼져있던 object와 collider를 다시 활성화

    public override void Update()
    {
        base.Update();
        CheckDieEnd();
    }
    
}
