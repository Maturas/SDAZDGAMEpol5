using UnityEngine;

namespace SDAZDGAMEpol5.GameLogic
{
    public class Point : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var playerController = other.gameObject.GetComponent<PlayerController>();
                playerController.OnPointCollected();
                Destroy(gameObject);
            }
        }
    }
}