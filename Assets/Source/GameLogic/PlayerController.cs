using System;
using UnityEngine;

namespace SDAZDGAMEpol5.GameLogic
{
    public class PlayerController : MonoBehaviour
    {
        // public float MovementAcceleration; // public field, serialized by default
        
        // [SerializeField] // how to serialize a private field
        // private float MovementAcceleration; // private field
        
        [field: SerializeField] // how to serialize a property
        private float MovementAcceleration { get; set; } // Property
        
        [field: SerializeField]
        private float JumpAcceleration { get; set; }
        
        private Rigidbody2D Rigid { get; set; }
        
        private float MoveDirection { get; set; } // -1 - move left, 1 - move right, 0 - don't move
        private bool ShouldJump { get; set; }
        private bool IsGrounded { get; set; }
        
        private void Start()
        {
            // Invoked once, at the beginning of this GameObject's life cycle
            Rigid = GetComponent<Rigidbody2D>(); // NEVER use GetComponent on Update or FixedUpdate!!!
            IsGrounded = false;
        }

        private void Update()
        {
            // Invoked every frame, warning: FPS varies per device/system/etc
            
            // GetKey - returns true while the key is pressed down (continuously)
            // GetKeyDown - returns true on one frame, when the user has pressed the key
            // GetKeyUp - returns true on one frame, when the user has released the key
            if (Input.GetKey(KeyCode.A))
            {
                MoveDirection = -1.0f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                MoveDirection = 1.0f;
            }
            else
            {
                MoveDirection = 0.0f;
            }

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
            {
                ShouldJump = true;
            }
        }

        private void FixedUpdate()
        {
            // Invoked every physics engine refresh, constant amount of refreshes per second on every device/system/etc

            // Horizontal movement
            Rigid.AddForce(Vector2.right * (MovementAcceleration * MoveDirection), ForceMode2D.Force);

            if (ShouldJump)
            {
                // Jump
                Rigid.AddForce(Vector2.up * JumpAcceleration, ForceMode2D.Impulse);

                ShouldJump = false;
            }
        }

        // Collision detection requirements:
        // Both objects have a collider
        // Detecting object has a rigidbody
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                // Hit the ground
                IsGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                // Hit the ground
                IsGrounded = false;
            }
        }
    }   
}