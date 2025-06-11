using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: Header("Animation")]
    [field: SerializeField] private EnemyAnimationData animationData;
    public EnemyAnimationData AnimationData { get { return animationData; } set { animationData = value; } }
    [field: SerializeField] private Animator animator;
    public Animator Animator { get { return animator; } set { animator = value; } }
    [field: SerializeField] private CapsuleCollider ccollider;
    public CapsuleCollider Ccollider { get { return ccollider; } set { ccollider = value; } }
    public EnemyStateMachine stateMachine;
    [field: SerializeField] public EnemySO Data { get; set; }
    private int health;
    public int Health { get { return health; } set { health = value; } }
    private bool isattacked = false;
    public bool Isattacked {  get { return isattacked; } set {  isattacked = value; } }

    private void Awake()
    {
        AnimationData.Initialize();

        animator = GetComponentInChildren<Animator>();
        ccollider = GetComponent<CapsuleCollider>();

        health = Data.HealthData.BaseHealth;

        stateMachine = new EnemyStateMachine(this);

        stateMachine.ChangeState(stateMachine.idleState);

    }
    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public void GetDamage(int damage) //-> 여기서 공격 받는것을 탐지
    {
        health -= damage;
        animator.SetTrigger(stateMachine.Enemy.AnimationData.Impactparameterhash);
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    public void Revive()
    {
        health = Data.HealthData.BaseHealth;
        stateMachine.ChangeState(stateMachine.idleState);
    }
}
