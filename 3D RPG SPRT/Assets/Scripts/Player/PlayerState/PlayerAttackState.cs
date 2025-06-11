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
    { // ���� �ִϸ��̼��� �����ϴ� �߰��뿡 target�� �������� �޴� �Լ��� ����(GetDamage)
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

    private void CheckEnemy() // Enemy�� ������ �տ��� ����� -> �ٽ� walkstate�� ��ȯ
    {
        Ray ray = new Ray(stateMachine.Player.gameObject.transform.position, stateMachine.Player.gameObject.transform.forward);

        if (!Physics.Raycast(ray, out RaycastHit hit, stateMachine.Player.Data.AttackData.AttackRange, stateMachine.Player.TargetLayermask))
        {
            stateMachine.Player.Gold += stateMachine.Player.Target.Data.GoldData.BaseGold;
            stateMachine.Player.Target = null;
            stateMachine.Player.UpdateGoldTxt(); // enemy�� �־��ٰ� �������ٴ� ���� �׾��ٴ� ��, �� ���� ��带 ��������
            stateMachine.ChangeState(stateMachine.WalkState);
        }
    }
}
