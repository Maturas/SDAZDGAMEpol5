using TMPro;
using UnityEngine;

namespace SDAZDGAMEpol5.GameLogic
{
    public class PlayerController : MonoBehaviour
    {
        // public float MovementAcceleration; // public field, serialized by default
        
        // [SerializeField] // how to serialize a private field
        // private float MovementAcceleration; // private field
        
        [field: SerializeField]
        private TextMeshProUGUI PointsCounter { get; set; }
        
        [field: SerializeField] // how to serialize a property
        private float MovementAcceleration { get; set; } // Property
        
        [field: SerializeField]
        private float GroundJumpAcceleration { get; set; }
        
        [field: SerializeField]
        private float AirJumpAcceleration { get; set; }
        
        [field: SerializeField]
        private int AllowedAirJumps { get; set; }
        
        private Rigidbody2D Rigid { get; set; }
        
        private float MoveDirection { get; set; } // -1 - move left, 1 - move right, 0 - don't move
        private bool ShouldJump { get; set; }
        private bool IsGrounded { get; set; }
        private int UsedAirJumps { get; set; }
        private bool IsAirJump { get; set; }
        private int CollectedPoints { get; set; }
        
        private void Start()
        {
            // Invoked once, at the beginning of this GameObject's life cycle
            Rigid = GetComponent<Rigidbody2D>(); // NEVER use GetComponent on Update or FixedUpdate!!!
            IsGrounded = false;
            UsedAirJumps = 0;
            SetPoints(0);
        }

        private void Update()
        {
            // Invoked every frame, warning: FPS varies per device/system/etc
            
            // GetKey - returns true while the key is pressed down (continuously)
            // GetKeyDown - returns true on one frame, when the user has pressed the key
            // GetKeyUp - returns true on one frame, when the user has released the key
            
            // Read movement input from the user's keyboard
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

            // Jump if space is pressed
            if (Input.GetKeyDown(KeyCode.Space) && !ShouldJump)
            {
                if (IsGrounded)
                {
                    // Jump from ground
                    ShouldJump = true;
                    IsAirJump = false;
                }
                else if (UsedAirJumps < AllowedAirJumps)
                {
                    // Air jump
                    ShouldJump = true;
                    IsAirJump = true;
                    UsedAirJumps++;
                }
            }
        }

        private void FixedUpdate()
        {
            // Invoked every physics engine refresh, constant amount of refreshes per second on every device/system/etc

            // Horizontal movement
            Rigid.AddForce(Vector2.right * (MovementAcceleration * MoveDirection), ForceMode2D.Force);

            if (ShouldJump)
            {
                var force = Vector2.up * (IsAirJump ? AirJumpAcceleration : GroundJumpAcceleration);
                
                // Jump
                Rigid.AddForce(force, ForceMode2D.Impulse);

                ShouldJump = false;
            }
        }

        public void OnPointCollected()
        {
            SetPoints(CollectedPoints + 1);
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
                UsedAirJumps = 0;
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

        private void SetPoints(int points)
        {
            CollectedPoints = points;
            PointsCounter.text = points.ToString();
        }
    }   
}