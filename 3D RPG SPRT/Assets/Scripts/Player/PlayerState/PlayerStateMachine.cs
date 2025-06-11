using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] private Player player;
    public Player Player { get { return player; } }
    [SerializeField] private float movementSpeed;
    public float MovementSpeed { get { return movementSpeed; } }
    [SerializeField] private float attackDamage;
    public float AttackDamage { get { return attackDamage; } }
    private Transform mainCameraTransform;
    public Transform MainCameraTransform { get { return mainCameraTransform; } set { mainCameraTransform = value; } }
    [SerializeField] private float walkmodifier;
    public float Walkmodifier { get { return walkmodifier; } set { walkmodifier = value; } }

    public PlayerWalkState WalkState;
    public PlayerAttackState AttackState;

    public PlayerStateMachine(Player player)
    {
        this.player = player;

        WalkState = new PlayerWalkState(this);
        AttackState = new PlayerAttackState(this);  

        MainCameraTransform = Camera.main.transform;

        movementSpeed = player.Data.WalkData.BaseSpeed;
        walkmodifier = player.Data.WalkData.walkspeedModifier;

        attackDamage = player.Data.AttackData.BaseAttackDamage;
    }
}
