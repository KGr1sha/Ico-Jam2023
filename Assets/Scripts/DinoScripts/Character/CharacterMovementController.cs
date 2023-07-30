using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace DinoScripts.Player
{


    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovingController : MonoBehaviour
    {
        [Header("Components.")]
        [SerializeField] private Rigidbody2D rb;

        [Header("Settings.")]
        [SerializeField] private float detectGroundRayLenght;
        [SerializeField] private float jumpForce;

        [Header("Development settings.")]
        [SerializeField] private bool showDetectGroundRay;


        private void Awake()
        {
            if (this.rb == null) this.rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (this.showDetectGroundRay)
            {
                Debug.DrawRay(transform.position, Vector3.down * this.detectGroundRayLenght, Color.red);
            }
        }
        public bool IsGround()
        {
            int groundLayerMask = LayerMask.GetMask("Ground");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, this.detectGroundRayLenght, groundLayerMask);
            return hit.collider;    
        }

        public void Jump() => this.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}