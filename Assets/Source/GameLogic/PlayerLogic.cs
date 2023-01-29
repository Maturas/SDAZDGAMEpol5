using System.Collections;
using TMPro;
using UnityEngine;

namespace SDAZDGAMEpol5.GameLogic
{
    public class PlayerLogic : MonoBehaviour
    {        
        [field: SerializeField]
        private SpriteRenderer SpriteRenderer { get; set; }
        
        [field: SerializeField]
        private PlayerController PlayerController { get; set; }
        
        [field: SerializeField]
        private CameraController CameraController { get; set; }
        
        [field: SerializeField]
        private TextMeshProUGUI PointsCounter { get; set; }
        
        [field: SerializeField]
        private GameObject GameOverScreen { get; set; }
        
        private int CollectedPoints { get; set; }
        private Coroutine CurrentFadeCoroutine { get; set; }

        private void Start()
        {
            CurrentFadeCoroutine = null;
            SetPoints(0);
        }

        private void OnDestroy()
        {
            if (CurrentFadeCoroutine != null)
            {
                StopCoroutine(CurrentFadeCoroutine);
                CurrentFadeCoroutine = null;
            }
        }

        public void KillPlayer()
        {
            GameOverScreen.SetActive(true);
            PointsCounter.gameObject.SetActive(false);
            PlayerController.enabled = false;
            CameraController.enabled = false;
            CurrentFadeCoroutine = StartCoroutine(FadeAwayPlayer());
        }
        
        public void OnPointCollected()
        {
            SetPoints(CollectedPoints + 1);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("DeadlyObstacle"))
            {
                KillPlayer();
            }
        }

        private void SetPoints(int points)
        {
            CollectedPoints = points;
            PointsCounter.text = points.ToString();
        }

        private IEnumerator FadeAwayPlayer()
        {
            while (SpriteRenderer.color.a > 0.0f)
            {
                var color = SpriteRenderer.color;
                color.a = Mathf.Clamp(color.a - Time.deltaTime, 0.0f, 1.0f);
                SpriteRenderer.color = color;
                yield return null;
            }

            CurrentFadeCoroutine = null;
        }
    }
}