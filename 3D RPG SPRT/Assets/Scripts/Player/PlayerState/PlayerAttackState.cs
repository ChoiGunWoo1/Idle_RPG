using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }
    private bool hasGivenDamage;
    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.Attackparameterhash);
        hasGivenDamage = false;
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.Attackparameterhash);
    }

    public override void Update()
    {
        base.Update();
        CheckEnemy();
        GiveDamage();
    }

    private void GiveDamage()
    { // 공격 애니매이션이 실행하는 중간쯤에 target이 데미지를 받는 함수를 실행(GetDamage)
        AnimatorStateInfo stateinfo = stateMachine.Player.Animator.GetCurrentAnimatorStateInfo(0);
        if(stateinfo.IsTag("Attack") && stateinfo.normalizedTime >= 0.5f && !hasGivenDamage)
        {
            if(stateMachine.Player.Target == null)
            {
                return;
            }
            stateMachine.Player.Target.GetDamage(stateMachine.Player.Data.AttackData.BaseAttackDamage);
            hasGivenDamage = true;
        }
        if(stateinfo.normalizedTime < 0.5f)
        {
            hasGivenDamage = false;
        }
    }

    private void CheckEnemy() // Enemy가 죽으면 앞에서 사라짐 -> 다시 walkstate로 전환
    {
        Ray ray = new Ray(stateMachine.Player.gameObject.transform.position, stateMachine.Player.gameObject.transform.forward);

        if (!Physics.Raycast(ray, out RaycastHit hit, stateMachine.Player.Data.AttackData.AttackRange, stateMachine.Player.TargetLayermask))
        {
            stateMachine.Player.Gold += stateMachine.Player.Target.Data.GoldData.BaseGold;
            stateMachine.Player.Target = null;
            stateMachine.Player.UpdateGoldTxt(); // enemy가 있었다가 없어졌다는 것은 죽었다는 것, 즉 얻은 골드를 갱신해줌
            stateMachine.ChangeState(stateMachine.WalkState);
        }
    }
}
