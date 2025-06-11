using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("Animation")]
    [field: SerializeField] private PlayerAnimationData animationData;
    public PlayerAnimationData AnimationData { get { return animationData; } set { animationData = value; } }
    [field: SerializeField] private Animator animator;
    public Animator Animator { get { return animator; } set { animator = value; } }

    private PlayerStateMachine stateMachine;
    [field : SerializeField] public PlayerSO Data { get; set; }

    private CharacterController characterController;
    public CharacterController Controller { get { return characterController; } set {  characterController = value; } }
    private ForceReciever freciever;
    public ForceReciever Freceiver {  get { return freciever; } set {  freciever = value; } }
    public LayerMask TargetLayermask;

    private Enemy target;
    public Enemy Target {  get { return target; } set {  target = value; } }

    private int gold = 0;
    public int Gold { get { return gold; } set { gold = value; } }

    [SerializeField] private TextMeshProUGUI GoldText;

    private void Awake()
    {
        AnimationData.Initialize();

        animator = GetComponentInChildren<Animator>();
        freciever = GetComponent<ForceReciever>();
        characterController = GetComponent<CharacterController>();

        stateMachine = new PlayerStateMachine(this);    

        stateMachine.ChangeState(stateMachine.WalkState);
        UpdateGoldTxt();

    }
    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public void UpdateGoldTxt() // 골드 표시 텍스트 업데이트
    {
        GoldText.text = $"Gold : {gold}";
    }
}
