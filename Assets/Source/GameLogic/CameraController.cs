using UnityEngine;

namespace SDAZDGAMEpol5.GameLogic
{
    public class CameraController : MonoBehaviour
    {
        [field: SerializeField]
        private Transform FollowTarget { get; set; }
        
        [field: SerializeField]
        private float SmoothDampTime { get; set; }
        
        [field: SerializeField]
        private float SmoothDampMaxSpeed { get; set; }

        [field: SerializeField]
        private bool FreezeXAxis { get; set; }
        
        [field: SerializeField]
        private bool FreezeYAxis { get; set; }
        
        [field: SerializeField]
        private bool FreezeZAxis { get; set; }
        
        private Vector3 _currentSmoothDampVelocity;

        private void Update()
        {
            if (FollowTarget == null)
                return;

            // Calculate target camera position based on target's position
            var currentPosition = transform.position;
            var currentTargetPosition = FollowTarget.position;

            // Freeze axes if necessary
            if (FreezeXAxis) 
                currentTargetPosition.x = currentPosition.x;

            if (FreezeYAxis) 
                currentTargetPosition.y = currentPosition.y;

            if (FreezeZAxis) 
                currentTargetPosition.z = currentPosition.z;

            // Possible solutions for smooth linear movement:
            // Vector3.Lerp
            // Vector3.MoveTowards
            // Vector3.SmoothDamp
            // Transform.Translate
            // Rigidbody2D.MovePosition

            transform.position = Vector3.SmoothDamp(currentPosition, currentTargetPosition,
                ref _currentSmoothDampVelocity, SmoothDampTime, SmoothDampMaxSpeed);
        }
    }
}