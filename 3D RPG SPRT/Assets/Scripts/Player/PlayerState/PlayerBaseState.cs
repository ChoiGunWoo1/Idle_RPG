using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public abstract class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine;
    }
    public virtual void Enter()
    {
   
    }

    public virtual void Exit()
    {

    }


    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {

    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, false);
    }
}
