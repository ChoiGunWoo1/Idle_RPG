using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [SerializeField] private Enemy enemy;
    public Enemy Enemy { get { return enemy; } }

    public EnemyIdleState idleState;
    public EnemyDieState dieState;
    public EnemyStateMachine(Enemy enemy)
    {
        this.enemy = enemy;
        idleState = new EnemyIdleState(this);
        dieState = new EnemyDieState(this);
    }
}
