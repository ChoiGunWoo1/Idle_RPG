using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string walkParameterName = "Walk";
    [SerializeField] private string attackParameterName = "Attack";

    private int walkparameterhash;
    public int Walkparameterhash { get { return walkparameterhash; } }
    private int attackparameterhash;
    public int Attackparameterhash { get { return attackparameterhash; } }
    public void Initialize()
    {
        walkparameterhash = Animator.StringToHash(walkParameterName);
        attackparameterhash = Animator.StringToHash(attackParameterName);
    }
}
