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
                var rigid = col.gameObject.GetComponent<Rigidbody2D>();
                
                if (rigid != null && rigid.bodyType != RigidbodyType2D.Static)
                    MovingPlatform.OnPlatformTriggerEnter(rigid);
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (!col.gameObject.isStatic)
            {
                var rigid = col.gameObject.GetComponent<Rigidbody2D>();
                
                if (rigid != null && rigid.bodyType != RigidbodyType2D.Static)
                    MovingPlatform.OnPlatformTriggerExit(rigid);
            }
        }
    }
}