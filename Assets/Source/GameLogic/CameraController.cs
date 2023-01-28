using UnityEngine;

namespace SDAZDGAMEpol5.GameLogic
{
    public class CameraController : MonoBehaviour
    {
        [field: SerializeField]
        private Transform FollowTarget { get; set; }

        private void Update()
        {
            if (FollowTarget == null)
                return;

            // Primitive 1:1 camera follow movement implementation
            var targetPosition = FollowTarget.position;
            targetPosition.z = transform.position.z;
            transform.position = targetPosition;
        }
    }
}