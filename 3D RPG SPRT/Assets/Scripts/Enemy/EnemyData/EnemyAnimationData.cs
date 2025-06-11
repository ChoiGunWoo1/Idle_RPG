using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyAnimationData
{
    [SerializeField] private string impactParameterName = "Impact";
    [SerializeField] private string dieParameterName = "Die";

    private int impactparameterhash;
    public int Impactparameterhash { get { return impactparameterhash; } }
    private int dieparameterhash;
    public int Dieparameterhash { get { return dieparameterhash; } }
    public void Initialize()
    {
        impactparameterhash = Animator.StringToHash(impactParameterName);
        dieparameterhash = Animator.StringToHash(dieParameterName);
    }
}
