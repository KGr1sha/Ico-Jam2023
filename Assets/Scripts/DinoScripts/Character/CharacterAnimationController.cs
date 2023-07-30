using DinoScripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationController : MonoBehaviour
{
    [Header("Components.")]
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterMovingController characterMovement;

    private static readonly int GameStartTrigger = Animator.StringToHash("GameStart");
    private static readonly int JumpTrigger = Animator.StringToHash("Jump");
    private static readonly int IsGround = Animator.StringToHash("IsGround");
    private static readonly int IsCrouchRun = Animator.StringToHash("IsCrouchRun");


    private void Awake()
    {
        if (this.animator == null) this.animator = GetComponent<Animator>();
        if (this.characterMovement == null) this.characterMovement = GetComponent<CharacterMovingController>();
    }

    private void Update()
    {
        bool isGround = this.characterMovement.IsGround();
        SetIsGround(isGround);
    }
    public void SetJump() => this.animator.SetTrigger(JumpTrigger);

    public void SetGameStart() => this.animator.SetTrigger(GameStartTrigger);

    public void SetIsGround(bool value) => this.animator.SetBool(IsGround, value);

    public void SetCrouchRun(bool value) => this.animator.SetBool(IsCrouchRun, value);

}
