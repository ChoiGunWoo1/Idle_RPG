using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.Walkparameterhash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.Walkparameterhash);
    }

    public override void Update()
    {
        base.Update();
        Move();
        CheckEnemy();
    }

    private void Move()
    {
        Vector3 movedir = new Vector3(0, 0, 1);
        movedir.Normalize();
        float speed = GetSpeed();
        stateMachine.Player.Controller.Move(((movedir * speed) + stateMachine.Player.Freceiver.Movement) * Time.deltaTime);
    }

    private float GetSpeed()
    {
        float movspeed = stateMachine.MovementSpeed * stateMachine.Walkmodifier;
        return movspeed;
    }

    private void CheckEnemy() // walk에서 enemy가 공격범위 내 있다면 attackstate로 전환
    {
        Ray ray = new Ray(stateMachine.Player.gameObject.transform.position, stateMachine.Player.gameObject.transform.forward);

        if(Physics.Raycast(ray, out RaycastHit hit, stateMachine.Player.Data.AttackData.AttackRange, stateMachine.Player.TargetLayermask))
        {
            stateMachine.Player.Target = hit.collider.gameObject.GetComponent<Enemy>();
            stateMachine.ChangeState(stateMachine.AttackState);
        }
    }
}
