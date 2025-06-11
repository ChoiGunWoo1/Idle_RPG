using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using JetBrains.Annotations;
//Enemy에게 필요한 정보를 담는 SO
[Serializable]
public class EnemyHealthData
{
    [field: Header("HealthData")]
    [field: SerializeField][field: Range(0, 100)] public int BaseHealth { get; set; } = 20;
}

[Serializable]
public class EnemyGoldData
{
    [field: Header("GoldData")]
    [field: SerializeField][field: Range(0, 100)] public int BaseGold { get; set; } = 5;
}


[CreateAssetMenu(fileName = "Enemy", menuName = "Characters/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public EnemyHealthData HealthData { get; set; }
    [field: SerializeField] public EnemyGoldData GoldData { get; set; }
}
