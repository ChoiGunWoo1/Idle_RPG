using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//Player에게 필요한 정보들을 담는 SO
[Serializable]
public class PlayerWalkData
{
    [field: SerializeField][field: Range(0f, 25f)] public float BaseSpeed { get; private set; } = 5f;

    [field: Header("WalkData")]
    [field: SerializeField][field: Range(0f, 2f)] public float walkspeedModifier = 0.225f;

    [field: Header("RunData")]
    [field: SerializeField][field: Range(0f, 2f)] public float runspeedModifier { get; private set; } = 1f;
}

[Serializable]
public class PlayerAttackData
{

    [field: SerializeField][field: Range(0, 25)] public int BaseAttackDamage { get; private set; } = 5;
    [field: SerializeField][field: Range(0f, 3f)] public float AttackRange { get; private set; } = 3f;
}

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field : SerializeField] public PlayerWalkData WalkData { get; private set; }
    [field : SerializeField] public PlayerAttackData AttackData { get; private set; }
}
