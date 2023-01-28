using UnityEngine;

namespace SDAZDGAMEpol5.GameLogic
{
    public class CameraController : MonoBehaviour
    {
        [field: SerializeField]
        private Transform FollowTarget { get; set; }
        
        [field: SerializeField]
        private float FollowTargetSpeed { get; set; }

        [field: SerializeField]
        private float FollowTargetDistanceThreshold { get; set; }

        [field: SerializeField]
        private bool FreezeXAxis { get; set; }
        
        [field: SerializeField]
        private bool FreezeYAxis { get; set; }
        
        [field: SerializeField]
        private bool FreezeZAxis { get; set; }
        
        private Vector3 LastTargetPosition { get; set; }

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

            // Don't follow the target if the distance threshold hasn't been reached
            if (Vector3.Distance(currentPosition, currentTargetPosition) < FollowTargetDistanceThreshold)
                return;

            // Possible solutions for smooth linear movement:
            // Vector3.Lerp
            // Vector3.MoveTowards
            // Vector3.SmoothDamp
            // Transform.Translate
            // Rigidbody2D.MovePosition
            var maxDistanceDelta = FollowTargetSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(currentPosition, currentTargetPosition, maxDistanceDelta);
            LastTargetPosition = currentTargetPosition;
        }
    }
}