using UnityEngine;

namespace SDAZDGAMEpol5.GameLogic
{
    public class MovingPlatformTrigger : MonoBehaviour
    {
        [field: SerializeField]
        private MovingPlatform MovingPlatform { get; set; }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.isStatic)
            {
                MovingPlatform.OnPlatformTriggerEnter(col.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (!col.gameObject.isStatic)
            {
                MovingPlatform.OnPlatformTriggerExit(col.transform);
            }
        }
    }
}