using DinoScripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(CharacterMovingController))]
[RequireComponent(typeof(CharacterAnimationController))]
public class Character : MonoBehaviour
{
    [Header("Components.")]
    [SerializeField] private CharacterAnimationController characterAnimation;
    [SerializeField] private CharacterMovingController characterMovement;


    [SerializeField] private UnityEvent jump;
    [SerializeField] private UnityEvent dead;
    [SerializeField] private UnityEvent crouchRunStart;
    [SerializeField] private UnityEvent crouchRunEnd;

    private void Awake()
    {
        if (this.characterAnimation == null) this.characterAnimation = GetComponent<CharacterAnimationController>();
        if (this.characterMovement == null) this.characterMovement = GetComponent<CharacterMovingController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                this.dead?.Invoke();
                break;
        }
    }
    private void OnJumpButtonDown()
    {
        if (this.characterMovement.IsGround())
        {
            this.characterMovement.Jump();
            this.characterAnimation.SetJump();
            this.jump?.Invoke();
        }  
    }   
    
    private void OnCrouchButtonDown()
    {
        if (this.characterMovement.IsGround())
        {
            this.characterAnimation.SetCrouchRun(true);
            this.crouchRunStart?.Invoke();
        }
    }

    private void OnCrouchButtonUp()
    {
        if (this.characterMovement.IsGround())
        {
            this.characterAnimation.SetIsGround(false);
            this.crouchRunEnd?.Invoke();
        }
    }

    private void OnGameStart()
    {
        this.characterAnimation.SetGameStart();
    }
}
