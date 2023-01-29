using UnityEngine;

namespace SDAZDGAMEpol5.GameLogic
{
    public class Point : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var playerLogic = other.gameObject.GetComponent<PlayerLogic>();
                playerLogic.OnPointCollected();
                Destroy(gameObject);
            }
        }
    }
}